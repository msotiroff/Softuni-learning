namespace LoggerSystem.Models.Factories
{
    using Contracts;
    using Enums;
    using Implementations.Errors;
    using System;
    using System.Globalization;
    using Common;

    public class ErrorFactory
    {
        public IError CreateError(string datetime, string inputErrorLevel, string message)
        {
            DateTime dateTime = DateTime.ParseExact(datetime, Constants.DateTimeFormat, CultureInfo.InvariantCulture);
            ErrorLevel errorLevel;
            var isErrorLevelValid = Enum.TryParse<ErrorLevel>(inputErrorLevel, out errorLevel);
            if (!isErrorLevelValid)
            {
                throw new ArgumentException(ErrorMessages.InvalidErrorLevel);
            }

            IError error = new Error(dateTime, errorLevel, message);

            return error;
        }
    }
}
