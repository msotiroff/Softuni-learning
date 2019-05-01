using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Web.Models;
using MyLibrary.Web.Models.Author;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public DetailsModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public BookDetailsViewModel BookViewModel { get; set; }

        [HttpGet("{id}")]
        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.BookViewModel = await this.db
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

            if (this.BookViewModel == null)
            {
                return RedirectToPage("/Home/Index");
            }

            return Page();
        }
    }
}