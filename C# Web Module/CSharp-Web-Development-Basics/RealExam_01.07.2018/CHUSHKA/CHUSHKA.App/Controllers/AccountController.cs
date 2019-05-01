namespace CHUSHKA.App.Controllers
{
    using AutoMapper;
    using CHUSHKA.App.Models.User;
    using CHUSHKA.Common.Notifications;
    using CHUSHKA.Services.Contracts;
    using SoftUni.WebServer.Mvc.Attributes.HttpMethods;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;

    public class AccountController : BaseController
    {
        private readonly IUserService userService;
        private readonly IHashService hashService;

        public AccountController(IUserService userService, IHashService hashService)
        {
            this.userService = userService;
            this.hashService = hashService;
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
            var loggedUser = this.userService.TryLogin(model.Username, passwordHash);
            if (loggedUser == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }

            var roles = new List<string>() { "User" };
            if (loggedUser.IsAdmin)
            {
                roles.Add("Admin");
            }

            this.SignIn(loggedUser.Email, loggedUser.Id, roles);
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
            var registeredUser = this.userService.Create(model.Email, model.Username, passwordHash, model.FullName);
            if (registeredUser == null)
            {
                this.ShowNotification(NotificationMessages.UserExist, NotificationType.Info);
                return View();
            }

            var roles = new List<string>() { "User" };
            if (registeredUser.IsAdmin)
            {
                roles.Add("Admin");
            }

            this.SignIn(model.Email, registeredUser.Id, roles);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(registeredUser));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (this.User.IsAuthenticated)
            {
                this.SignOut();
            }
            
            return RedirectToHome();
        }
    }
}
