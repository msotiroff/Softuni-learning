namespace Library.Web
{
    public class WebConstants
    {
        public const string ExceptionLogFilePath = @"wwwroot\logs\ExceptionLogs.txt";
        public const string ClientActiviryLogFilePath = @"wwwroot\logs\ClientActivityLogs.txt";

        public const string NotificationMessageKey = "message";
        public const string NotificationTypeKey = "notificationType";

        public const string CurrentUserSessionKey = "__AuthenticatedUserKey__";
        public const string AdminUsername = "Admin";
        public const string AdminPassword = "Admin123";

        public const int BooksCountOnPage = 15;
        public const int MoviesCountOnPage = 15;
        public const int IndexEntryCountOnPage = 20;
    }
}
