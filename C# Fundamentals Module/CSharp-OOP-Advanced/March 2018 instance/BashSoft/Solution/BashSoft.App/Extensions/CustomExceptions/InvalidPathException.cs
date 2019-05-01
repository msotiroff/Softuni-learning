namespace BashSoft.App.Extensions.CustomExceptions
{
    using System;

    public class InvalidPathException : Exception
    {
        private const string InvalidPath = "The source does not exist.";

        public override string Message => InvalidPath;
    }
}
