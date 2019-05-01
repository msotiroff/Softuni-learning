namespace MyLibrary.Web.Pages.Book
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using MyLibrary.Web.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class AddModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public AddModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        [Required]
        public string Title { get; set; }

        [BindProperty]
        [Required]
        public string Description { get; set; }

        [Url]
        [BindProperty]
        public string CoverImageUrl { get; set; }

        [BindProperty]
        public IEnumerable<string> SelectedAuthors { get; set; }

        public IEnumerable<SelectListItem> AllAuthors { get; set; }

        public void OnGet()
        {
            this.AllAuthors = this.db
                .Authors
                .OrderBy(a => a.Name)
                .Select(a => new SelectListItem(a.Name, a.Name));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var authors = await this.GetAuthors(this.SelectedAuthors);

                var book = new Book
                {
                    Title = Title,
                    Description = Description,
                    CoverImageUrl = CoverImageUrl,
                    Authors = authors.Select(a => new BookAuthor { AuthorId = a.Id }).ToList()
                };

                await this.db.Books.AddAsync(book);
                await this.db.SaveChangesAsync();
            }

            return RedirectToPage("/Home/Index");
        }
        
        private async Task<IEnumerable<Author>> GetAuthors(IEnumerable<string> authorsNames)
        {
            var authors = new HashSet<Author>();

            foreach (var authorName in authorsNames)
            {
                var author = await this.db.Authors.FirstOrDefaultAsync(a => a.Name == authorName);
                if (author == null)
                {
                    await this.db
                        .Authors.AddAsync(new Author
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