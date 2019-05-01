namespace Judge.App.Controllers
{
    using AutoMapper;
    using Judge.App.Models.User;
    using Judge.Common.Notifications;
    using Judge.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Contracts;

    public class UserController : BaseController
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;

        public UserController(IUserService userService, IHashService hashService)
        {
            this.userService = userService;
            this.hashService = hashService;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                this.ShowNotification(NotificationMessages.PasswordDoesNotMatch);
                return View();
            }

            if (!this.IsValidModel(model))
            {
                this.ShowNotification(NotificationMessages.MissingRequiredData);
                return View();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);

            var success = this.userService.Add(model.Email, model.FullName, passwordHash);

            if (!success)
            {
                this.ShowNotification(NotificationMessages.SomethingWentWrong);
                return View();
            }

            return RedirectToLogin();
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = this.userService.TryLogin(model.Email, this.hashService.ComputeHash(model.Password));

            if (user == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }

            this.SignIn(user.FullName);
            this.SetUserDetailedSession(Mapper.Map<Identity>(user));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToHome();
        }
    }
}
