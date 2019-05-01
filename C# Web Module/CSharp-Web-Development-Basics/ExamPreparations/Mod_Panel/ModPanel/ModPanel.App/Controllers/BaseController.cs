namespace ModPanel.App.Controllers
{
    using Common.Notifications;
    using Models.User;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Interfaces;
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
            this.Model[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.Model[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.Model[AdminDisplayKey] = this.User.IsAuthenticated ? this.Identity.IsAdmin ? "flex" : "none" : "none";
            this.Model[ShowNotificationKey] = "false";
        }

        protected Identity Identity { get; private set; }

        protected void ShowNotification(string message, NotificationType notificationType = NotificationType.Error)
        {
            this.Model.Data[ShowNotificationKey] = "true";
            this.Model.Data["message"] = message;
            this.Model.Data["class"] = notificationType.ToString();
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
        
        public override void OnAuthentication()
        {
            this.SetAuthentication();

            this.Identity = Request.Session.Get<Identity>(IdentityKey);

            this.Model.Data[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.Model.Data[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.Model[AdminDisplayKey] = this.User.IsAuthenticated ? this.Identity.IsAdmin ? "flex" : "none" : "none";
            this.Model.Data["username"] = this.User.IsAuthenticated ? this.Identity.Email : "guest";

            base.OnAuthentication();
        }
    }
}
