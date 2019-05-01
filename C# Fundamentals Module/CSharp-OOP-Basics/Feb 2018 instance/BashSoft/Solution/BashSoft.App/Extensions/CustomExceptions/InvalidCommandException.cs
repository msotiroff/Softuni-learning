namespace BashSoft.App.Extensions.CustomExceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        public const string InvalidCommand = "The command {0} is invalid!";
        
        public InvalidCommandException(string commandName)
            : base(string.Format(InvalidCommand, commandName))
        {
        }
    }
}