using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        private const string EndCommand = "END";

        private StorageMaster storageMaster;
        private bool isRunning;

        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            string result = string.Empty;

            while (this.isRunning)
            {
                var inputLine = Console.ReadLine().Split();

                var commandName = inputLine.First();
                var commandParams = inputLine.Skip(1).ToArray();

                try
                {
                    switch (commandName)
                    {
                        case "AddProduct":
                            var productType = commandParams[0];
                            var price = double.Parse(commandParams[1]);
                            result = this.storageMaster.AddProduct(productType, price);
                            break;

                        case "RegisterStorage":
                            var storageType = commandParams[0];
                            var name = commandParams[1];
                            result = this.storageMaster.RegisterStorage(storageType, name);
                            break;

                        case "SelectVehicle":
                            var storageName = commandParams[0];
                            var garageSlot = int.Parse(commandParams[1]);
                            result = this.storageMaster.SelectVehicle(storageName, garageSlot);
                            break;

                        case "LoadVehicle":
                            result = this.storageMaster.LoadVehicle(commandParams);
                            break;

                        case "SendVehicleTo":
                            var sourceName = commandParams[0];
                            var sourceGarageSlot = int.Parse(commandParams[1]);
                            var destinationName = commandParams[2];
                            result = this.storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName);
                            break;

                        case "UnloadVehicle":
                            var storage = commandParams[0];
                            var slot = int.Parse(commandParams[1]);
                            result = this.storageMaster.UnloadVehicle(storage, slot);
                            break;

                        case "GetStorageStatus":
                            var storeName = commandParams[0];
                            result = this.storageMaster.GetStorageStatus(storeName);
                            break;

                        case EndCommand:
                            this.isRunning = false;
                            result = this.storageMaster.GetSummary();
                            break;

                        default:
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    result = $"Error: {ex.Message}";
                }

                Console.WriteLine(result);
            }
        }
    }
}
