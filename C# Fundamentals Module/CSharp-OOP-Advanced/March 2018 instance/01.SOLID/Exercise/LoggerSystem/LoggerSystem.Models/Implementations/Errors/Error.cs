namespace LoggerSystem.Models.Implementations.Errors
{
    using Contracts;
    using Enums;
    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel errorLevel, string messgae)
        {
            this.DateTime = dateTime;
            this.ErrorLevel = errorLevel;
            this.Message = messgae;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel ErrorLevel { get; }
    }
}
