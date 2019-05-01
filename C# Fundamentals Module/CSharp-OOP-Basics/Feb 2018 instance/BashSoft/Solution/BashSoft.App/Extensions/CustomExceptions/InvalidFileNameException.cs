namespace BashSoft.App.Extensions.CustomExceptions
{
    using System;

    public class InvalidFileNameException : Exception
    {
        private const string ForbiddenSymbolsContainedInName =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public override string Message => ForbiddenSymbolsContainedInName;
    }
}
