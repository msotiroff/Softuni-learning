namespace MyLibrary.Web.Pages.Author
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using MyLibrary.Data;
    using MyLibrary.Models;
    using System.Threading.Tasks;

    public class CreateModel : PageModel
    {
        private readonly MyLibraryDbContext db;

        public CreateModel(MyLibraryDbContext db)
        {
            this.db = db;
        }
        
        public string ReturnUrl { get; set; }

        public string ErrorMessage { get; set; }

        [BindProperty]
        public string Name { get; set; }

        public void OnGet(string returnUrl, string errorMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                this.ErrorMessage = errorMessage;
            }

            this.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            this.ReturnUrl = this.TempData["returnUrl"].ToString();

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                var errorMessage = "Author name could not be empty";
                return RedirectToPage("/author/create", new { returnUrl = this.TempData["returnUrl"].ToString(), errorMessage = errorMessage });
            }

            var authorExist = await this.db.Authors.AnyAsync(a => a.Name == this.Name);
            if (authorExist)
            {
                var errorMessage = "This author already exist";
                return RedirectToPage("/author/create", new { returnUrl = this.TempData["returnUrl"].ToString(), errorMessage = errorMessage });
            }

            await this.db.Authors.AddAsync(new Author
            {
                Name = this.Name
            });

            await this.db.SaveChangesAsync();

            return RedirectToPage(this.ReturnUrl);
        }
    }
}