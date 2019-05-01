namespace LoggerSystem.App
{
    using IO;
    using Models.Contracts;
    using Models.Enums;
    using Models.Factories;
    using Models.Implementations.Loggers;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var layoutFactory = new LayoutFactory();
            var appenderFactory = new AppenderFactory(layoutFactory);
            var errorFactory = new ErrorFactory();

            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var appenders = ConfigureAppenders(appenderFactory);

            ILogger logger = new Logger(appenders);

            var engine = new Engine(logger, errorFactory, reader, writer);
            engine.Run();
        }

        private static ICollection<IAppender> ConfigureAppenders(AppenderFactory appenderFactory)
        {
            var appenders = new List<IAppender>();

            var appendersCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appendersCount; i++)
            {
                var inputArgs = Console.ReadLine().Split();

                var appenderType = inputArgs[0];

                var layoutType = inputArgs[1];

                var errorLevel = inputArgs.Length > 2
                    ? inputArgs[2]
                    : ErrorLevel.INFO.ToString();


                var currentAppender = appenderFactory.CreateAppender(appenderType, layoutType, errorLevel);

                appenders.Add(currentAppender);
            }

            return appenders;
        }
    }
}
