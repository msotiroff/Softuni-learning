﻿namespace Notes.App.Controllers
{
    using Notes.App.Models.User;
    using Notes.Common.Notifications;
    using SimpleMvc.Framework.Contracts;
    using SimpleMvc.Framework.Controllers;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public abstract class BaseController : Controller
    {
        protected const string IdentityKey = "Identity";
        protected const string GuestDisplayKey = "guestDisplay";
        protected const string UserDisplayKey = "userDisplay";
        protected const string ShowNotificationKey = "show-notification";

        protected BaseController()
        {
            this.ViewModel[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.ViewModel[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.ViewModel[ShowNotificationKey] = "false";
        }

        protected Identity Identity { get; private set; }

        protected void ShowNotification(string message, NotificationType notificationType = NotificationType.error)
        {
            this.ViewModel[ShowNotificationKey] = "true";
            this.ViewModel["message"] = message;
            this.ViewModel["class"] = notificationType.ToString();
        }

        protected string ValidateModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            return validationResults.FirstOrDefault()?.ToString();
        }

        protected IActionResult RedirectToLogin() => this.Redirect("/user/login");

        protected IActionResult RedirectToHome() => this.Redirect("/home/index");

        protected override void InitializeController()
        {
            base.InitializeController();

            this.Identity = Request.Session.Get<Identity>(IdentityKey);
            
            this.ViewModel[GuestDisplayKey] = this.User.IsAuthenticated ? "none" : "flex";
            this.ViewModel[UserDisplayKey] = this.User.IsAuthenticated ? "flex" : "none";
            this.ViewModel["username"] = this.User.IsAuthenticated ? this.User.Name : "guest";
        }

        protected void SetUserDetailedSession(Identity identity)
            => this.Request.Session.Add(IdentityKey, identity);
    }
}
