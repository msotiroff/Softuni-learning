using RecyclingStation.Common;
using RecyclingStation.Interfaces;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.Core
{
    public class WasteProcessingManager : IWasteProcessingManager
    {
        private IGarbageProcessor garbageProcessor;

        public WasteProcessingManager(IGarbageProcessor garbageProcessor)
        {
            this.garbageProcessor = garbageProcessor;    
        }

        public string ChangeWasteProcessingRequirements(string[] arguments)
        {
            var energyBalance = double.Parse(arguments[0]);
            var capitalBalance = double.Parse(arguments[1]);
            var wasteType = this.GetWasteType(arguments[2]);

            var reqirementsHolder = (IRequirementsHolder)this.garbageProcessor;

            reqirementsHolder.ChangeRequirements(wasteType, energyBalance, capitalBalance);

            return Constants.RequirementsChanged;
        }

        private Type GetWasteType(string typeName)
        {
            var type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IWaste)))
                .First(t => t.Name == $"{typeName}{Constants.WasteSuffix}");

            return type;
        }
    }
}
