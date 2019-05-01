namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Models;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Library.Web.Infrastructure.Filters;
    using Library.Web.Models.Borrower;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BorrowerController : BaseController
    {
        public BorrowerController(LibraryDbContext dbContext) 
            : base(dbContext) { }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Create(string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        [AuthorizedOnly]
        public async Task<IActionResult> Create(BorrowerCreateViewModel model, string returnUrl = null)
        {
            ViewData["returnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                this.ShowModelStateError();
                return View();
            }

            var borrower = new Borrower
            {
                Name = model.Name,
                Address = model.Address
            };

            await this.DbContext.AddAsync(borrower);
            await this.DbContext.SaveChangesAsync();

            this.ShowNotification($"Borrower {model.Name} created successfully!", NotificationType.Success);

            return LocalRedirect(returnUrl);
        }
    }
}