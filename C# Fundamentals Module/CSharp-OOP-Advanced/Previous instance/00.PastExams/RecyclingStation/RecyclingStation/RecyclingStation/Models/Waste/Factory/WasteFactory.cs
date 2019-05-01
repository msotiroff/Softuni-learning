using RecyclingStation.Common;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.Models.Waste.Factory
{
    public class WasteFactory : IWasteFactory
    {
        public IWaste CreateWaste(string[] arguments)
        {
            // {name}|{weight}|{volumePerKg}|{type}

            var name = arguments[0];
            var weght = double.Parse(arguments[1]);
            var volumePerKg = double.Parse(arguments[2]);
            var type = arguments[3];

            var wasteType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IWaste))
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == $"{type}{Constants.WasteSuffix}");

            // Throw if null...

            var waste = (IWaste)Activator.CreateInstance(wasteType, new object[] { name, weght, volumePerKg });

            return waste;
        }
    }
}
