namespace KittenShop.App.Controllers
{
    using Common.Notifications;
    using KittenShop.App.Models.Shopping;
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

        protected const string ShoppingCartKey = "ShoppingCartId";
        protected const string GuestDisplayKey = "guestDisplay";
        protected const string UserDisplayKey = "userDisplay";

        protected BaseController()
        {
            this.Model[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.Model[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.Model[ShowNotificationKey] = "false";
        }

        protected Identity Identity { get; private set; }

        protected void ShowNotification(string message, NotificationType notificationType = NotificationType.error)
        {
            this.Model[ShowNotificationKey] = "true";
            this.Model["message"] = message;
            this.Model["class"] = notificationType.ToString();
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

        protected override void InitializeUser()
        {
            base.InitializeUser();
            this.Identity = Request.Session.Get<Identity>(IdentityKey);

            this.Model[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.Model[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.Model["username"] = this.User.IsAuthenticated ? this.User.Name : "guest";
        }

        protected void SetUpUserDetailedSession(Identity identity)
        {
            this.Request.Session.Add(IdentityKey, identity);
            this.Request.Session.Add(ShoppingCartKey, new ShoppingCart());
        }
    }
}
