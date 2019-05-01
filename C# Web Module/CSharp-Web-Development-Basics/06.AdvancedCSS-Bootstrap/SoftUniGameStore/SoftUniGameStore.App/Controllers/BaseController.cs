namespace SoftUniGameStore.App.Controllers
{
    using HTTPServer.Enums;
    using HTTPServer.Http;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
    using Models.Shopping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using Views;

    public abstract class BaseController
    {
        private const string HtmlFileExtension = ".html";
        private const string LayoutPath = @"Shared\_Layout.html";
        private const string ViewsPath = @"..\..\..\Views";
        private const string ContentPlaceholder = "{{{content}}}";
        private const string ShowErrorKey = "showError";
        private const string ErrorKey = "error";
        private const string AdminDisplayKey = "adminDisplay";
        
        protected const string AnonymousKey = "anonymousDisplay";
        protected const string ShowResultKey = "showResult";
        protected const string AuthenticatedKey = "authenticatedDisplay";

        protected BaseController(IHttpRequest request)
        {
            this.Request = request;
            this.EnsureShoppingCartExist();

            this.ViewData = new Dictionary<string, string>
            {
                [AuthenticatedKey] = this.GetAuthenticatedDisplay(),
                [AnonymousKey] = this.GetAnonynousDisplay(),
                [ShowErrorKey] = "none",
                [AdminDisplayKey] = this.GetAdminDisplay()
            };
        }

        protected IHttpRequest Request { get; private set; }

        protected IDictionary<string, string> ViewData { get; private set; }

        // Checks whether the given object is in a valid state, depending on its attributes:
        protected bool VerifyModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var result in validationResults)
                {
                    if (result != ValidationResult.Success)
                    {
                        this.ShowError(result.ErrorMessage);
                        return false;
                    }
                }
            }

            return true;
        }

        protected void ShowError(string errorMessage)
        {
            this.ViewData[ShowResultKey] = "none";
            this.ViewData[ShowErrorKey] = "block";
            this.ViewData[ErrorKey] = errorMessage;
        }

        protected IHttpResponse RedirectResponse(string route)
            => new RedirectResponse(route);

        protected IHttpResponse FileViewResponse(string fileName)
        {
            var result = this.ProcessFileHtml(fileName);

            if (this.ViewData.Any())
            {
                foreach (var value in this.ViewData)
                {
                    result = result.Replace($"{{{{{{{value.Key}}}}}}}", value.Value);
                }
            }

            return new ViewResponse(HttpStatusCode.Ok, new FileView(result));
        }

        private string ProcessFileHtml(string fileName)
        {
            var layoutFilePath = Path.Combine(ViewsPath, LayoutPath);
            var viewFilePath = Path.Combine(ViewsPath, fileName) + HtmlFileExtension;

            var layoutHtml = File.ReadAllText(layoutFilePath);
            var fileHtml = File.ReadAllText(viewFilePath);

            var result = layoutHtml.Replace(ContentPlaceholder, fileHtml);

            return result;
        }

        private string GetAdminDisplay()
        {
            if (!this.Request.Session.Contains(SessionStore.CurrentUserIsAdminKey))
            {
                return "none";
            }

            return (bool)this.Request.Session[SessionStore.CurrentUserIsAdminKey] == true ? "block" : "none";
        }

        private string GetAnonynousDisplay()
        {
            if (this.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                return "none";
            }

            return "block";
        }

        private string GetAuthenticatedDisplay()
        {
            if (this.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                return "block";
            }

            return "none";
        }

        private void EnsureShoppingCartExist()
        {
            if (!this.Request.Session.Contains(SessionStore.CurrentShoppingCartSessionKey))
            {
                this.Request.Session.Add(SessionStore.CurrentShoppingCartSessionKey, new ShoppingCartSessionModel());
            }
        }
    }
}