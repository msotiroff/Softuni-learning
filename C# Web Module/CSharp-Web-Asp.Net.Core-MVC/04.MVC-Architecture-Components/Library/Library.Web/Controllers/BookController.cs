namespace Library.Web.Controllers
{
    using Infrastructure.Collections;
    using Infrastructure.Extensions.Enums;
    using Library.Data;
    using Library.Models;
    using Library.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Models.Author;
    using Models.Book;
    using Models.Interfaces;
    using Models.Status;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static WebConstants;

    public class BookController : BaseController
    {
        public BookController(LibraryDbContext dbContext)
            : base(dbContext) { }
        
        public IActionResult Index(int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);

            var books = this.DbContext
                .Books
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.IsBorrowed ? "Borrowed" : "At home",
                    Originators = b.Authors
                        .Select(a => new AuthorViewModel
                        {
                            Id = a.AuthorId,
                            Name = a.Author.Name,
                        })
                        .Cast<IOriginator>()
                        .ToList()
                })
                .OrderBy(b => b.Title);

            var totalPages = Math.Max(1, (int)Math.Ceiling(books.Count() / (double)BooksCountOnPage));
            pageIndex = Math.Min(pageIndex, totalPages);

            var booksToShow = books
                .Skip((pageIndex - 1) * BooksCountOnPage)
                .Take(BooksCountOnPage)
                .ToList();

            var model = new PaginatedList<BookIndexViewModel>(booksToShow, pageIndex, totalPages);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.DbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookDetailsViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    CoverImageUrl = b.CoverImageUrl,
                    IsBorrowed = b.IsBorrowed,
                    Status = b.IsBorrowed ? "Borrowed" : "At home",
                    Authors = b.Authors
                        .Select(a => new AuthorViewModel
                        {
                            Id = a.AuthorId,
                            Name = a.Author.Name
                        })
                        .ToArray()
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return RedirectToHome();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allAuthors = await GetAllAuthors();

            var model = new BookCreateViewModel
            {
                AllAuthors = allAuthors
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllAuthors = await this.GetAllAuthors();
                this.ShowModelStateError();
                return View(model);
            }
            if (!model.SelectedAuthors.Any())
            {
                model.AllAuthors = await this.GetAllAuthors();
                this.ShowNotification("You have to choose minimum one author!");
                return View(model);
            }

            var authors = await this.GetAuthors(model.SelectedAuthors);

            var book = new Book
            {
                Title = model.Title,
                Description = model.Description,
                CoverImageUrl = model.CoverImageUrl,
                Authors = authors.Select(a => new BookAuthor { AuthorId = a.Id }).ToList()
            };

            await this.DbContext.Books.AddAsync(book);
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Book {book.Title} created successfully", NotificationType.Success);

            return RedirectToAction("Details", "Book", new { id = book.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Borrow(int id)
        {
            var allRegisteredBorrowers = await this.GetAllRegisteredBorrowers();

            var model = await this.DbContext
                .Books
                .Where(b => b.Id == id)
                .Select(b => new BookBorrowingViewModel
                {
                    Id = b.Id,
                    BookTitle = b.Title,
                    DateBorrowed = DateTime.Today,
                    ExpirationDate = DateTime.Today.AddMonths(1),
                    Borrowers = allRegisteredBorrowers
                })
                .FirstOrDefaultAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Borrow(BookBorrowingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Borrowers = await this.GetAllRegisteredBorrowers();
                this.ShowModelStateError();
                return View(model);
            }
                
            if (model.ExpirationDate != null)
            {
                if (model.ExpirationDate <= model.DateBorrowed)
                {
                    model.Borrowers = await this.GetAllRegisteredBorrowers();
                    this.ShowNotification("Expiration date should be after date of borrowing!");
                    return View(model);
                }
            }

            var book = await this.DbContext.Books.FirstOrDefaultAsync(b => b.Id == model.Id);
            book.IsBorrowed = true;

            var status = new BookStatus
            {
                BookId = model.Id,
                BorrowerId = int.Parse(model.SelectedBorrowerId),
                DateBorrowed = model.DateBorrowed,
                ExpirationDate = model.ExpirationDate
            };

            await this.DbContext.AddAsync(status);
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Book {book.Title} successfully borrowed!", NotificationType.Success);

            return RedirectToHome();
        }

        [HttpPost]
        public async Task<IActionResult> Return(int bookId)
        {
            if (bookId == default(int))
            {
                this.ShowNotification("Missing Book identifier!");
                return RedirectToHome();
            }

            var book = await this.DbContext
                .Books
                .Where(b => b.Id == bookId)
                .Include(b => b.Statuses)
                .FirstOrDefaultAsync(b => b.Id == bookId);

            book.IsBorrowed = false;

            var status = book.Statuses.Last();
            status.DateReturned = DateTime.Today;

            this.DbContext.Update(book);
            this.DbContext.Update(status);

            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Book {book.Title} successfully returned!", NotificationType.Success);
            
            return RedirectToHome();
        }

        [HttpGet]
        public async Task<IActionResult> History(int id)
        {
            var statuses = await this.DbContext
                .BookStatuses
                .Where(s => s.BookId == id)
                .OrderByDescending(s => s.DateBorrowed)
                .ThenBy(s => s.DateReturned)
                .ThenByDescending(s => s.ExpirationDate)
                .Select(s => new BookStatusViewModel
                {
                    BookTitle = s.Book.Title,
                    BorrowerName = s.Borrower.Name,
                    BorrowerAddress = s.Borrower.Address,
                    DateBorrowed = s.DateBorrowed.ToShortDateString(),
                    ExpirationDate = s.ExpirationDate != null ? s.ExpirationDate.Value.ToShortDateString() : "No expiration date",
                    DateReturned = s.DateReturned != null ? s.DateReturned.Value.ToShortDateString() : "Not returned yet"
                })
                .ToListAsync();

            return View(statuses);
        }

        private async Task<IEnumerable<Author>> GetAuthors(IEnumerable<string> authorsNames)
        {
            var authors = new HashSet<Author>();

            foreach (var authorName in authorsNames)
            {
                var author = await this.DbContext.Authors.FirstOrDefaultAsync(a => a.Name == authorName);

                authors.Add(author);
            }

            return authors;
        }

        private async Task<List<SelectListItem>> GetAllAuthors()
        {
            return await this.DbContext
                            .Authors
                            .OrderBy(a => a.Name)
                            .Select(a => new SelectListItem(a.Name, a.Name))
                            .ToListAsync();
        }
        
        private async Task<List<SelectListItem>> GetAllRegisteredBorrowers()
        {
            return await this
                            .DbContext
                            .Borrowers
                            .Select(b => new SelectListItem { Text = b.Name, Value = b.Id.ToString() })
                            .ToListAsync();
        }
    }
}