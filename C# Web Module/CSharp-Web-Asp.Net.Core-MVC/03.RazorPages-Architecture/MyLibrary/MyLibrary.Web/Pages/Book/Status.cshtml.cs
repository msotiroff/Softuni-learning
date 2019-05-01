namespace MyLibrary.Web.Pages.Book
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Web.Models.Status;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class StatusModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public StatusModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<StatusViewModel> Statuses { get; set; }

        public async Task OnGetAsync(int id)
        {
            this.Statuses = await this.db
                .Statuses
                .Where(s => s.BookId == id)
                .OrderByDescending(s => s.DateBorrowed)
                .ThenBy(s => s.ExpirationDate)
                .Select(s => new StatusViewModel
                {
                    BookTitle = s.Book.Title,
                    BorrowerName = s.Borrower.Name,
                    BorrowerAddress = s.Borrower.Address,
                    DateBorrowed = s.DateBorrowed.ToShortDateString(),
                    ExpirationDate = s.ExpirationDate.HasValue ? s.ExpirationDate.Value.ToShortDateString() : "No expiration date",
                    DateReturned = s.DateReturned != null ? s.DateReturned.Value.ToShortDateString() : "Not returned yet"
                })
                .ToListAsync();
        }
    }
}