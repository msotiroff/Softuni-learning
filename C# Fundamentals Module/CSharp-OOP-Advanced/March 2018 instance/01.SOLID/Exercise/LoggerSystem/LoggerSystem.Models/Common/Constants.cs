namespace LoggerSystem.Models.Common
{
    using System;
    using System.Globalization;
    using System.IO;

    public class Constants
    {
        private static string ApplicationPath = Directory.GetCurrentDirectory();
        public static string OutputDirectory = ApplicationPath +  @"\IO\Output\";

        private static string FilePrepend = DateTime.Now.ToString("yyyyMMdd_", CultureInfo.InvariantCulture);
        public static string DefaultLogFileName = FilePrepend + "LogFile.txt";

        public const string DateTimeFormat = "M/d/yyyy h:mm:ss tt";
        public const string SimpleLayoutFormat = "{0} - {1} - {2}";
    }
}
