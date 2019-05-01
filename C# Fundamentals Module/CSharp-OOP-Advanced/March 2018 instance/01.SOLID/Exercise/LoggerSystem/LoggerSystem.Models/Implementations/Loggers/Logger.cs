namespace LoggerSystem.Models.Implementations.Loggers
{
    using Contracts;
    using System.Collections.Generic;

    public class Logger : ILogger
    {
        private ICollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (var appender in this.appenders)
            {
                if (appender.ErrorLevel <= error.ErrorLevel)
                {
                    appender.Append(error);
                }
            }
        }
    }
}
