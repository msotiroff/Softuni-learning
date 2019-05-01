namespace Library.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.IO;

    public static class ILoggerExtentions
    {
        public static bool LogToFile(this ILogger logger, string filePath, LogLevel logLevel, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return false;
            }

            var log = $"{logLevel.ToString()}: {message}{Environment.NewLine}";

            try
            {
                File.AppendAllText(filePath, log);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
