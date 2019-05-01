namespace FestivalManager.Core
{
    using Contracts;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Core.IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private const string EndCommand = "END";
        private const string RegisterSetCommand = "RegisterSet";
        private const string SignUpPerformerCommand = "SignUpPerformer";
        private const string RegisterSongCommand = "RegisterSong";
        private const string AddSongToSetCommand = "AddSongToSet";
        private const string AddPerformerToSetCommand = "AddPerformerToSet";
        private const string RepairInstrumentsCommand = "RepairInstruments";
        private const string LetsRockCommand = "LetsRock";

        private const string ErrorMEssageFormat = "ERROR: {0}";

        private bool isRunning;
        private ISetController setController;
        private IFestivalController festivalController;
        private IReader reader;
        private IWriter writer;

        public Engine(ISetController setController, IFestivalController festivalController, IReader reader, IWriter writer)
        {
            this.setController = setController;
            this.festivalController = festivalController;
            this.reader = reader;
            this.writer = writer;
            this.isRunning = false;
        }
        
        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var input = this.reader.ReadLine();

                this.isRunning = input != EndCommand;

                var result = this.ProcessCommand(input);

                if (!string.IsNullOrEmpty(result))
                {
                    this.writer.WriteLine(result);
                }
            }
        }

        public string ProcessCommand(string input)
        {
            var inputParams = input.Split();

            var commandName = inputParams.First();
            var commandParams = inputParams.Skip(1).ToArray();

            string result = string.Empty;

            try
            {
                switch (commandName)
                {
                    case RegisterSetCommand:
                        result = this.festivalController.RegisterSet(commandParams);
                        break;
                    case SignUpPerformerCommand:
                        result = this.festivalController.SignUpPerformer(commandParams);
                        break;
                    case RegisterSongCommand:
                        result = this.festivalController.RegisterSong(commandParams);
                        break;
                    case AddSongToSetCommand:
                        result = this.festivalController.AddSongToSet(commandParams);
                        break;
                    case AddPerformerToSetCommand:
                        result = this.festivalController.AddPerformerToSet(commandParams);
                        break;
                    case RepairInstrumentsCommand:
                        result = this.festivalController.RepairInstruments(commandParams);
                        break;
                    case LetsRockCommand:
                        result = this.setController.PerformSets();
                        break;
                    case EndCommand:
                        result = this.festivalController.ProduceReport();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                result = string.Format(ErrorMEssageFormat, ex.Message);
            }

            return result;
        }
    }
}