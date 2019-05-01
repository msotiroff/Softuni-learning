namespace BashSoft.App.Extensions.CustomExceptions
{
    using System;

    public class InvalidStringException : Exception
    {
        public const string NullOrEmptyValue = "The value of the variable CANNOT be null or empty!";

        public override string Message => NullOrEmptyValue;
    }
}
