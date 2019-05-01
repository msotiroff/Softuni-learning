using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Models;
using MyLibrary.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyLibrary.Web.Pages.Book
{
    public class AddModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public AddModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public BookCreateBindingModel BookBindingModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var authorsNames = Regex.Split(BookBindingModel.Authors, @"[^A-Za-z\s]").Select(a => a.Trim());
                var authors = await this.GetAuthors(authorsNames);

                var book = new MyLibrary.Models.Book
                {
                    Title = BookBindingModel.Title,
                    Description = BookBindingModel.Description,
                    CoverImageUrl = BookBindingModel.CoverImageUrl,
                    Authors = authors.Select(a => new BookAuthor { AuthorId = a.Id }).ToList()
                };

                await this.db.Books.AddAsync(book);
                await this.db.SaveChangesAsync();
            }

            return RedirectToPage("/Home/Index");
        }
        
        private async Task<IEnumerable<MyLibrary.Models.Author>> GetAuthors(IEnumerable<string> authorsNames)
        {
            var authors = new HashSet<MyLibrary.Models.Author>();

            foreach (var authorName in authorsNames)
            {
                var author = await this.db.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
                if (author == null)
                {
                    await this.db
                        .Authors.AddAsync(new MyLibrary.Models.Author
                        {
                            Name = authorName
                        });

                    await this.db.SaveChangesAsync();
                    author = await this.db.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
                }

                authors.Add(author);
            }

            return authors;
        }
    }
}