namespace KittenShop.App.Controllers
{
    using AutoMapper;
    using KittenShop.App.Models.User;
    using KittenShop.Common.Notifications;
    using KittenShop.Services.Contracts;
    using KittenShop.Services.Implementations;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Attributes.Security;
    using SimpleMvc.Framework.Interfaces;

    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;

        public AccountController()
        {
            this.userService = new UserService();
            this.hashService = new HashService();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);
            var loggedUser = this.userService.TryLogin(model.Email, passwordHash);
            if (loggedUser == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }

            this.SignIn(loggedUser.Username);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(loggedUser));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.IsAuthenticated)
            {
                return RedirectToHome();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return View();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);
            var registeredUser = this.userService.Create(model.Email, model.Username, passwordHash);
            if (registeredUser == null)
            {
                this.ShowNotification(NotificationMessages.UserExist);
                return View();
            }

            this.SignIn(model.Email);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(registeredUser));

            return RedirectToHome();
        }

        [HttpGet]
        [PreAuthorize]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToHome();
        }
    }
}
