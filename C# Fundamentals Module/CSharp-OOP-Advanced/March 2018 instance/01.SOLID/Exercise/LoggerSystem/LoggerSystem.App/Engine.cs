namespace LoggerSystem.App
{
    using Contracts;
    using Models.Contracts;
    using Models.Factories;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ErrorFactory errorFactory;
        private readonly ILogger logger;
        private bool isRunning;

        public Engine(ILogger logger, ErrorFactory errorFactory, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.errorFactory = errorFactory;
            this.logger = logger;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            var inputLine = this.reader.ReadLine();

            while (this.isRunning)
            {
                if (inputLine == "END")
                {
                    this.isRunning = false;
                    continue;
                }

                var errorParams = inputLine.Split('|');

                var level = errorParams[0];
                var dateTime = errorParams[1];
                var message = errorParams[2];

                IError error = this.errorFactory.CreateError(dateTime, level, message);

                this.logger.Log(error);

                inputLine = this.reader.ReadLine();
            }

            this.PrintResults();
        }

        private void PrintResults()
        {
            this.writer.WriteLine("Logger info");

            foreach (var appender in this.logger.Appenders)
            {
                this.writer.WriteLine(appender.ToString());
            }
        }
    }
}
