namespace BashSoft.App.Extensions.CustomExceptions
{
    using System;

    public class InvalidCommandArgumentsException : Exception
    {
        public const string InvalidCommandParams = "Command {0} requires {1} parameters!";

        public InvalidCommandArgumentsException(string message)
            : base(message)
        {
        }

        public InvalidCommandArgumentsException(string commandName, int paramsCount)
            : base(string.Format(InvalidCommandParams, commandName, paramsCount))
        {
        }
    }
}
