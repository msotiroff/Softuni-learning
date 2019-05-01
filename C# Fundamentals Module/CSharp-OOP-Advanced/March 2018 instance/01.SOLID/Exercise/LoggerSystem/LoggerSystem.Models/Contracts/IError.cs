namespace LoggerSystem.Models.Contracts
{
    using Enums;
    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ErrorLevel ErrorLevel { get; }
    }
}