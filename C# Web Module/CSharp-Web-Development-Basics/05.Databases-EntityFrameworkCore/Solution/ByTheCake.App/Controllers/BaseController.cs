namespace ByTheCake.App.Controllers
{
    using HTTPServer.Enums;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
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

        private const string AnonymousKey = "anonymousDisplay";
        private const string ShowErrorKey = "showError";
        private const string ErrorKey = "error";
        protected const string ShowResultKey = "showResult";

        protected const string AuthenticatedKey = "authenticatedDisplay";

        protected BaseController()
        {
            this.ViewData = new Dictionary<string, string>
            {
                [AuthenticatedKey] = "block",
                [AnonymousKey] = "block",
                [ShowErrorKey] = "none"
            };
        }

        protected IDictionary<string, string> ViewData { get; private set; }

        // Checks whether the given object is in a valid state, depending on its attributes:
        protected bool VerifyModelState(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
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
    }
}
