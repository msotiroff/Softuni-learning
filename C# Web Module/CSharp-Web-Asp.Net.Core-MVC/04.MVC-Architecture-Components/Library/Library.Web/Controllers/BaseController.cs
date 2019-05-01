namespace Library.Web.Controllers
{
    using Library.Data;
    using Library.Web.Infrastructure.Extensions.Enums;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Linq;
    using static WebConstants;

    public class BaseController : Controller
    {
        public BaseController(LibraryDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected LibraryDbContext DbContext { get; set; }

        protected IActionResult RedirectToHome() => new RedirectResult("/");
        
        protected internal void ShowNotification(string notificationMessage, NotificationType notificationType = NotificationType.Danger)
        {
            this.TempData[NotificationMessageKey] = notificationMessage;
            this.TempData[NotificationTypeKey] = notificationType;
        }

        protected void ShowModelStateError()
        {
            var firstOccuredErrorMsg =
                ModelState
                .Values
                .FirstOrDefault(v => v.Errors.Any())
                ?.Errors
                .FirstOrDefault()
                ?.ErrorMessage;

            this.ShowNotification(firstOccuredErrorMsg);
        }
    }
}