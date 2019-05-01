namespace MyLibrary.Web.Pages.Home
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Web.Infrastructure.Collections;
    using MyLibrary.Web.Models;
    using MyLibrary.Web.Models.Author;
    using System;
    using System.Linq;

    public class IndexModel : PageModel
    {
        private const int BooksCountOnPage = 15;

        private readonly MyLibraryDbContext db;

        public IndexModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public string SearchTerm { get; set; }
        
        public PaginatedList<BookIndexViewModel> Books { get; set; }

        public void OnGet(string searchTerm = "", int pageIndex = 1)
        {
            pageIndex = Math.Max(1, pageIndex);
            this.SearchTerm = searchTerm != null ? searchTerm.ToLower().Trim() : "";

            var books = this.db
                .Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Author)
                .Where(b => b.Title.ToLower().Contains(this.SearchTerm.ToLower())
                    || b.Authors.Any(a => a.Author.Name.ToLower().Contains(this.SearchTerm.ToLower())))
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.IsBorrowed ? "Borrowed" : "At home",
                    Authors = b.Authors
                        .Select(a => new AuthorViewModel
                        {
                            Id = a.AuthorId,
                            Name = a.Author.Name,
                        })
                        .ToList()
                })
                .OrderBy(b => b.Title);

            var totalPages = (int)Math.Ceiling(books.Count() / (double)BooksCountOnPage);
            pageIndex = Math.Min(pageIndex, Math.Max(1, totalPages));

            var booksToShow = books
                .Skip((pageIndex - 1) * BooksCountOnPage)
                .Take(BooksCountOnPage)
                .ToList();

            this.Books = new PaginatedList<BookIndexViewModel>(booksToShow, pageIndex, totalPages);
        }
    }
}