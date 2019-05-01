namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Library.Web.Infrastructure.Filters;
    using Library.Web.Models;
    using Library.Web.Models.Author;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class AuthorController : BaseController
    {
        public AuthorController(LibraryDbContext dbContext) 
            : base(dbContext) { }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await this.DbContext
                 .Authors
                 .Where(a => a.Id == id)
                 .Select(a => new AuthorDetailsViewModel
                 {
                     Name = a.Name,
                     Books = a.Books
                     .Select(b => new BookConciseViewModel
                     {
                         Id = b.BookId,
                         Title = b.Book.Title,
                         Status = b.Book.IsBorrowed ? "Borrowed" : "At home"
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
        [AuthorizedOnly]
        public IActionResult Create() => View();

        [HttpPost]
        [AuthorizedOnly]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                this.ShowNotification("Author name can not be empty!");
                return View();
            }

            var authorExist = await this.DbContext.Authors.AnyAsync(a => a.Name == name);
            if (authorExist)
            {
                this.ShowNotification("Author already exist!");
                return RedirectToAction("Create", "Book");
            }

            await this.DbContext.Authors.AddAsync(new Library.Models.Author { Name = name });
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Author {name} created successfully!", NotificationType.Success);

            return RedirectToAction("Create", "Book");
        }
    }
}