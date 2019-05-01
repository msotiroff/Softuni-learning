namespace Library.Web.Infrastructure.Extensions
{
    using Library.Web.Infrastructure.Extensions.Enums;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using static WebConstants;

    public static class HtmlHelperExtensions
    {
        private const string NotificationTag = 
            @"<div class='text-center'>
                <span class='text-{0}'>
                    <b>{1}</b>
                </span>
              </div>";

        /// <summary>
        /// Displays the notification set in TempDataDictionary, if exist
        /// Works with default text coloring, given by Bootstrap
        /// </summary>
        /// <returns>IHtmlContent</returns>
        public static IHtmlContent DisplayNotification(this IHtmlHelper html)
        {
            var tempDataDict = html.TempData;

            string message = null;
            NotificationType notificationType = NotificationType.Info;

            if (tempDataDict.ContainsKey(NotificationMessageKey))
            {
                message = tempDataDict[NotificationMessageKey].ToString();
            }
            if (tempDataDict.ContainsKey(NotificationTypeKey))
            {
                Enum.TryParse<NotificationType>(tempDataDict[NotificationTypeKey].ToString(), out notificationType);
            }

            var notification = string.Format(NotificationTag, notificationType.ToString().ToLower(), message ?? string.Empty);

            return html.Raw(notification);
        }
    }
}
