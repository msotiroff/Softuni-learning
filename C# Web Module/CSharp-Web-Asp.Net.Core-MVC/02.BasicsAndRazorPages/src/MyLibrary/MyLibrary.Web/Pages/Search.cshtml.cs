using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Data;
using MyLibrary.Web.Models;
using MyLibrary.Web.Models.Search;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibrary.Web.Pages
{
    public class SearchModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public SearchModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public SearchResultViewModel SearchResult { get; set; }

        [HttpGet("{searchTerm}")]
        public async Task OnGet(string searchTerm)
        {
            var authors = await this.db
                .Authors
                .Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()))
                .Select(a => new AuthorViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToListAsync();

            var books = await this.db
                .Books
                .Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()))
                .Select(b => new BookConciseViewModel
                {
                    Id = b.Id,
                    Title = b.Title
                })
                .ToListAsync();

            this.SearchResult = new SearchResultViewModel
            {
                SearchTerm = searchTerm,
                Authors = authors,
                Books = books
            };
        }
    }
}