namespace WizMail.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using WizMail.App.Models.User;
    using WizMail.Common.Notifications;
    using WizMail.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using Infrastructure.Attributes;
    using System.Linq;
    using WizMail.App.Infrastructure.Extensions;

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

            this.SignIn(loggedUser.Username, loggedUser.Id);
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
            var registeredUser = this.userService.Create(model.Username, model.FirstName, model.LastName, passwordHash);
            if (registeredUser == null)
            {
                this.ShowNotification(NotificationMessages.UserExist);
                return View();
            }

            this.SignIn(model.Username, registeredUser.Id);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(registeredUser));

            return RedirectToHome();
        }

        [HttpGet]
        [AuthorizedOnly]
        public IActionResult Logout()
        {
            this.SignOut();
            this.DropDownUserDetailedSession();
            return RedirectToLogin();
        }
    }
}
