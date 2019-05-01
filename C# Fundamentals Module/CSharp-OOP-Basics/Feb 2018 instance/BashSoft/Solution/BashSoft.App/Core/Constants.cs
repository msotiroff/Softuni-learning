namespace BashSoft.App.Core
{
    public class Constants
    {
        public static readonly string StudentsDataFilePath = $@"{SessionData.currentPath}\IO\Files\data.txt";

        public static readonly string HelpFilePath = $@"{SessionData.currentPath}\IO\Files\getHelp.txt";

        public static readonly string ReadingData = "Reading data...";

        public static readonly string DataUnloaded = "Database dropped!";

        public static readonly string DataRead = "Data read!";

        public static readonly string FilesRead = "Files read!";

        public static readonly string ReadingFiles = "Reading files...";

        public static readonly string ComparingFiles = "Comparing files...";

        public static readonly string MismatchByLine = "Mismatch at line {0} -- expected: \"{1}\", actual: \"{2}\"";

        public static readonly string NoMismatches = "Files are identical. There are no mismatches.";

        public static readonly string FileOpened = "File {0} was successfully opened.";

        public static readonly string DirectoryCreationSuccessful = "Directory {0} was successfully created.";

        public static readonly string InvalidArguments = "Invalid argumnts!";

        public static readonly string RelativePathChanged = "Relative path changed successfully";

        public static readonly string AbsolutePathChanged = "Absolute path changed successfully";
    }
}
