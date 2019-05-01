namespace Library.Web.Infrastructure.Filters
{
    using Library.Web.Controllers;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using static WebConstants;

    public class AuthorizedOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var contextAccessor = context.HttpContext.RequestServices.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
            var session = contextAccessor.HttpContext.Session;

            if (session.GetString(CurrentUserSessionKey) == null)
            {
                var controller = context.Controller as BaseController;
                controller.ShowNotification("You should be logged in in order to access this resourse!", NotificationType.Warning);
                
                var returnUrl = context.HttpContext.Request.Path.HasValue ? context.HttpContext.Request.Path.Value : "/";

                context.Result = new RedirectToActionResult("login", "account", new { returnUrl });
            }
        }
    }
}
