namespace LoggerSystem.Models.Implementations
{
    using Contracts;
    using Enums;

    public class FileAppender : IAppender
    {
        private ILogFile logFile;

        public FileAppender(ILogFile logFile, ILayout layout, ErrorLevel errorLevel)
        {
            this.logFile = logFile;
            this.Layout = layout;
            this.ErrorLevel = errorLevel;
        }

        public ILayout Layout { get; }

        public ErrorLevel ErrorLevel { get; }

        public int MessagesAppended { get; private set; }

        public int FileSize => this.logFile.Size;

        public void Append(IError error)
        {
            this.MessagesAppended++;

            var formattedError = this.Layout.FormatError(error);

            this.logFile.WriteToFile(formattedError);
        }

        public override string ToString()
        {
            var result = $"Appender type: {this.GetType().Name}, " +
                $"Layout type: {this.Layout.GetType().Name}, " +
                $"Report level: {this.ErrorLevel}, " +
                $"Messages appended: {this.MessagesAppended}, " +
                $"File size: {this.FileSize}";

            return result;
        }
    }
}