namespace MyLibrary.Web.Pages.Book
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReturnBookModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public ReturnBookModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        public string BorrowerName { get; set; }

        public string DateBorrowed { get; set; }

        public string ExpirationDate { get; set; }

        public string BookTitle { get; set; }

        [BindProperty]
        public int BookId { get; set; }

        [BindProperty]
        public bool ReturnConfirmed { get; set; }

        public async Task OnGetAsync(int id)
        {
            var book = await this.db.Books
                .Include(b => b.Statuses)
                .Include(b => b.Statuses)
                .ThenInclude(s => s.Borrower)
                .FirstOrDefaultAsync(b => b.Id == id);

            this.BookTitle = book.Title;
            this.DateBorrowed = book.Statuses.Last().DateBorrowed.ToShortDateString();
            this.ExpirationDate = book.Statuses.Last().ExpirationDate.HasValue 
                    ? book.Statuses.Last().ExpirationDate.Value.ToShortDateString() 
                    : "No expiration date";
            this.BorrowerName = book.Statuses.Last().Borrower.Name;
            this.BookId = book.Id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (this.ReturnConfirmed)
            {
                var book = await this.db.Books.Include(b => b.Statuses).FirstOrDefaultAsync(b => b.Id == this.BookId);
                book.IsBorrowed = false;

                var status = book.Statuses.Last();
                status.DateReturned = DateTime.Today;

                this.db.Books.Update(book);
                this.db.Statuses.Update(status);
                await this.db.SaveChangesAsync();
            }

            return RedirectToPage($"/book/details", new { id = this.BookId });
        }
    }
}