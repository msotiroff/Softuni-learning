namespace ModPanel.App.Controllers
{
    using AutoMapper;
    using ModPanel.App.Infrastructure.Extensions;
    using ModPanel.App.Models.User;
    using ModPanel.Common.Notifications;
    using ModPanel.Models.Common;
    using ModPanel.Services.Contracts;
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Linq;
    using System.Text;

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
            var loggedUser = this.userService.TryLogin(model.Email, passwordHash);
            if (loggedUser == null)
            {
                this.ShowNotification(NotificationMessages.InvalidLoginAttempt);
                return View();
            }
            else if (!loggedUser.IsApproved)
            {
                this.ShowNotification(NotificationMessages.WaitingForApprovement);
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

            this.Model["options-positions"] = this.BuildpPositionOptionsHtml();

            return View();
        }

        private string BuildpPositionOptionsHtml()
        {
            var builder = new StringBuilder();

            var allPositions = Enum
                .GetNames(typeof(PositionType))
                .Select(p => p = p.Replace("_", " "))
                .ForEach(p => builder.AppendLine($"<option value='{p}'>{p}</option>"));

            return builder.ToString();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var modelStateError = this.ValidateModelState(model);
            if (modelStateError != null)
            {
                this.ShowNotification(modelStateError);
                return this.Register();
            }

            var passwordHash = this.hashService.ComputeHash(model.Password);
            var registeredUser = this.userService.Create(model.Email, passwordHash, model.Position);
            if (registeredUser == null)
            {
                this.ShowNotification(NotificationMessages.UserExist, NotificationType.Info);
                return View();
            }

            this.ShowNotification(NotificationMessages.RegistrationSuccessful, NotificationType.Success);
            return this.Login();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectToHome();
        }
    }
}
