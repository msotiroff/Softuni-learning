namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Library.Web.Infrastructure.Filters;
    using Library.Web.Infrastructure.Helpers.Interfaces;
    using Library.Web.Models.Account;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using static WebConstants;

    public class AccountController : BaseController
    {
        private readonly IHashProvider hashProvider;
        private ISession session;

        public AccountController(LibraryDbContext dbContext, IHashProvider hashProvider, IHttpContextAccessor httpContextAccessor) 
            : base(dbContext)
        {
            this.hashProvider = hashProvider;
            this.session = httpContextAccessor.HttpContext.Session;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            ViewData["returnUrl"] = returnUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "/")
        {
            ViewData["returnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                this.ShowModelStateError();
                return View();
            }

            var isLoggedCorrectly = await this
                .DbContext
                .Users
                .AnyAsync(u => u.Username == model.Username 
                    && u.PasswordHash == this.hashProvider.ComputeHash(model.Password));

            if (!isLoggedCorrectly)
            {
                this.ShowNotification("Invalid login attempt!", NotificationType.Danger);
                return View();
            }

            this.session.SetString(CurrentUserSessionKey, model.Username);

            return LocalRedirect(returnUrl);
        }
        
        [AuthorizedOnly]
        public IActionResult Logout()
        {
            this.session.Remove(CurrentUserSessionKey);

            return RedirectToHome();
        }
    }
}