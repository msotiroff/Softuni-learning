namespace MyLibrary.Web.Pages.Borrower
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using System.Threading.Tasks;

    public class AddModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public AddModel(MyLibraryDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public int BookId { get; set; }

        [BindProperty]
        public string ReturnUrl { get; set; }
        
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Address { get; set; }

        public void OnGet(int bookId, string returnUrl = "/")
        {
            this.BookId = bookId;

            if (Url.IsLocalUrl(returnUrl))
            {
                this.ReturnUrl = returnUrl;
            }
            else
            {
                this.ReturnUrl = "/";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var borrower = new Borrower
            {
                Name = this.Name,
                Address = this.Address ?? "No address"
            };

            await this.db.Borrowers.AddAsync(borrower);
            await this.db.SaveChangesAsync();

            return RedirectToPage(this.ReturnUrl, new { id = this.BookId });
        }
    }
}