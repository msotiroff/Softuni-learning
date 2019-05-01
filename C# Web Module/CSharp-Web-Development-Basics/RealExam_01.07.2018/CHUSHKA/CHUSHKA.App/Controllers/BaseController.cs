namespace CHUSHKA.App.Controllers
{
    using Common.Notifications;
    using Models.User;
    using SoftUni.WebServer.Mvc.Controllers;
    using SoftUni.WebServer.Mvc.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        private const string IdentityKey = "Identity";
        private const string ShowNotificationKey = "show-notification";

        protected const string GuestDisplayKey = "guestDisplay";
        protected const string UserDisplayKey = "userDisplay";
        protected const string AdminDisplayKey = "adminDisplay";

        protected BaseController()
        {
            this.ViewData[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.ViewData[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.ViewData[AdminDisplayKey] = this.User.IsAuthenticated ? this.IsUserInRoleAdmin() ? "flex" : "none" : "none";
            this.ViewData[ShowNotificationKey] = "false";
        }

        protected Identity Identity { get; private set; }

        public override void OnAuthentication()
        {
            this.SetAuthentication();

            this.Identity = Request.Session.Get<Identity>(IdentityKey);

            this.ViewData[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.ViewData[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.ViewData[AdminDisplayKey] = this.User.IsAuthenticated ? this.IsUserInRoleAdmin() ? "flex" : "none" : "none";
            this.ViewData["username"] = this.User.IsAuthenticated ? this.Identity.Username : "guest";

            base.OnAuthentication();
        }

        protected void ShowNotification(string message, NotificationType notificationType = NotificationType.Warning)
        {
            this.ViewData[ShowNotificationKey] = "true";
            this.ViewData["message"] = message;
            this.ViewData["class"] = notificationType.ToString();
        }
		
		protected string ValidateModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return validationResults.FirstOrDefault()?.ToString();
        }

        protected IActionResult RedirectToLogin() => this.RedirectToAction("/account/login");

        protected IActionResult RedirectToHome() => this.RedirectToAction("/home/index");
        
        protected void SetUpUserDetailedSession(Identity identity)
        {
            this.Request.Session.Add(IdentityKey, identity);
        }

        protected bool IsUserInRoleAdmin() => this.User.Roles.Any(r => r == "Admin");
    }
}
