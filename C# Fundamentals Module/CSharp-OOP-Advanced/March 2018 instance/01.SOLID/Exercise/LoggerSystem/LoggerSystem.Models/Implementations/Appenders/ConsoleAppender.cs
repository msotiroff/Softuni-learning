namespace LoggerSystem.Models.Implementations.Appenders
{
    using Contracts;
    using Enums;
    using System;

    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel errorLevel)
        {
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            var formattedError = this.Layout.FormatError(error);
            this.MessagesAppended++;

            Console.WriteLine(formattedError);
        }

        public override string ToString()
        {
            var result = $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ErrorLevel}," +
                $" Messages appended: {this.MessagesAppended}";

            return result;
        }
    }
}
