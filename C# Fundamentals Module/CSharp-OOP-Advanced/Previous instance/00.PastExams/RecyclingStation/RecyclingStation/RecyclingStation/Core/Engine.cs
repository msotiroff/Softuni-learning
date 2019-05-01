using RecyclingStation.Common;
using RecyclingStation.Interfaces;
using RecyclingStation.Models.Waste.Factory;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;

namespace RecyclingStation.Core
{
    public class Engine : IEngine
    {
        #region Fields
        private bool isRunning;
        private IReader reader;
        private IWriter writer;

        private IWasteFactory factory;
        private IGarbageProcessor garbageProcessor;
        private IRepository repository;
        private IWasteProcessingManager wasteManager;
        #endregion

        #region Constructors
        public Engine(IReader reader, IWriter writer,
            IWasteFactory wasteFactory, IGarbageProcessor garbageProcessor,
            IRepository repository, IWasteProcessingManager wasteManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.factory = wasteFactory;
            this.garbageProcessor = garbageProcessor;
            this.repository = repository;
            this.wasteManager = wasteManager;
        }
        #endregion

        #region Methods
        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                var inputLine = this.reader.ReadLine();

                this.isRunning = inputLine != Constants.EndCommand;

                var inputParams = inputLine.Split();

                var command = inputParams.First();

                try
                {
                    this.ProcessCommand(inputParams, command);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.AppendLine(ex.Message);
                }
            }

            this.writer.WriteAllText();
        }

        private void ProcessCommand(string[] inputParams, string command)
        {
            string[] commandParams;

            switch (command)
            {
                case "ProcessGarbage":

                    commandParams = inputParams.Last().Split('|');
                    IWaste waste = this.factory.CreateWaste(commandParams);
                    var data = this.garbageProcessor.ProcessWaste(waste);
                    this.repository.UpdateData(data);
                    var lineToAppend = string.Format(Constants.GarbageProcessedMsg,
                        waste.Weight.ToString(Constants.FloatingPointNumbersFormat),
                        waste.Name);
                    this.writer.AppendLine(lineToAppend);

                    break;

                case "Status":

                    var status = this.repository.GetCurrentStatus();
                    this.writer.AppendLine(status);

                    break;

                case "ChangeManagementRequirement":
                    commandParams = inputParams.Last().Split('|');

                    var line = this.wasteManager.ChangeWasteProcessingRequirements(commandParams);
                    this.writer.AppendLine(line);

                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
