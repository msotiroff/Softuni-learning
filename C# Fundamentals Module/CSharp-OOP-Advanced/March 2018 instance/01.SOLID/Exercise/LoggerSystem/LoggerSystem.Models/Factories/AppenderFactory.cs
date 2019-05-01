namespace LoggerSystem.Models.Factories
{
    using Common;
    using Contracts;
    using Enums;
    using Implementations;
    using Implementations.Appenders;
    using System;

    public class AppenderFactory
    {
        private readonly LayoutFactory layoutFactory;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender CreateAppender(string appenderType, string layoutType, string inputErrorLevel)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);

            ErrorLevel errorLevel;
            var isErrorLevelValid = Enum.TryParse<ErrorLevel>(inputErrorLevel, out errorLevel);
            if (!isErrorLevelValid)
            {
                throw new ArgumentException(ErrorMessages.InvalidErrorLevel);
            }

            IAppender appender = null;

            switch (appenderType)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case nameof(FileAppender):
                    ILogFile fileProvider = new LogFile(Constants.DefaultLogFileName);
                    appender = new FileAppender(fileProvider, layout, errorLevel);
                    break;
                default:
                    throw new ArgumentException(ErrorMessages.InvalidAppenderType);
            }

            return appender;
        }
    }
}
