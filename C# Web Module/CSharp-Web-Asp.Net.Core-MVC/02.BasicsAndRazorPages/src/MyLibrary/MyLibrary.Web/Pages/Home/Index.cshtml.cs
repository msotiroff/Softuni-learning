namespace MyLibrary.Web.Pages.Home
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Web.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class IndexModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public IndexModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<BookIndexViewModel> Books { get; set; }
        
        public async Task OnGetAsync()
        {
            this.Books = await this.db
                .Books
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.IsBorrowed ? "Borrowed" : "At home",
                    Authors = string.Join(", ", b.Authors.Select(a => a.Author.Name))
                })
                .ToListAsync();
        }
    }
}