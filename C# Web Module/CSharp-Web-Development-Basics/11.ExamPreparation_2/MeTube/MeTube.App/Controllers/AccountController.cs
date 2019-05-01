namespace MeTube.App.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using MeTube.App.Models.User;
    using MeTube.Common.Notifications;
    using MeTube.Services.Contracts;
    using MeTube.Services.Models.Tube;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;

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

            this.SignIn(loggedUser.Email, loggedUser.Id);
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

            this.SignIn(model.Email, registeredUser.Id);
            this.SetUpUserDetailedSession(Mapper.Map<Identity>(registeredUser));

            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            this.DropDownUserDetailedSession();
            return RedirectToHome();
        }

        [HttpGet]
        public IActionResult Profile()
        {
            if (!this.User.IsAuthenticated)
            {
                return RedirectToLogin();
            }

            var profile = this.userService.GetById(this.Identity.Id);

            this.Model["email"] = profile.Email;
            this.Model["tubes"] = this.GetTubeElements(profile.Tubes);

            return View();
        }

        private string GetTubeElements(ICollection<TubeShortDetailsServiceModel> tubes)
        {
            var builder = new StringBuilder();

            var rowCounter = 1;

            foreach (var tube in tubes)
            {
                var tableRow = $@"<tr>
                                    <td>{rowCounter++}</td>
                                    <td>{tube.Title}</td>
                                    <td>{tube.Author}</td>
                                    <td>
                                        <a href='/tube/details?id={tube.Id}'>Details</a>
                                    </td>
                                </tr>";

                builder.AppendLine(tableRow);
            }

            return builder.ToString();
        }
    }
}
