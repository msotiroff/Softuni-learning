namespace MvcFramework.Controllers
{
    using Interfaces;
    using Models;
    using Security;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.CompilerServices;
    using ViewEngine.ActionResults;
    using Views;
    using WebServer.Http;
    using WebServer.Http.Contracts;

    public abstract class Controller
    {
        protected Controller()
        {
            this.Model = new ViewModel();
            this.User = new Authentication();
        }
        
        protected internal Authentication User { get; private set; }

        protected internal IHttpRequest Request { get; internal set; }

        protected ViewModel Model { get; }
        
        protected IViewable View([CallerMemberName] string caller = "")
        {
            this.InitializeViewModelData();

            var controllerName = this.GetControllerName();

            var fullQualifiedName = this.GetQualifiedName(controllerName, caller);

            var view = new View(fullQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
            => new RedirectResult(redirectUrl);

        protected bool IsValidModel(object model)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, validationContext, validationResults, true);

            return isValid;
        }

        protected internal void InitializeController()
        {
            var user = this.Request
                .Session
                .Get<string>(SessionStore.CurrentUserKey);

            if (user != null)
            {
                this.User = new Authentication(user);
            }
        }

        protected void SignIn(string name)
            => this.Request.Session.Add(SessionStore.CurrentUserKey, name);

        protected void SignOut() => this.Request.Session.Clear();

        private string GetControllerName()
            => this.GetType()
                   .Name
                   .Replace(MvcContext.Get.ControllersSuffix, string.Empty);

        private string GetQualifiedName(string controllerName, string caller)
            => string.Format(
                "{0}\\{1}\\{2}",
                MvcContext.Get.ViewsFolder,
                controllerName,
                caller);

        private void InitializeViewModelData()
            => this.Model["displayType"] = this.User.IsAuthenticated ? "block" : "none";
    }
}
