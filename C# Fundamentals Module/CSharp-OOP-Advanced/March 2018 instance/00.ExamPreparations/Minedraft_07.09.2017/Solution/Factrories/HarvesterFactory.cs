using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        var typeName = args[0];
        var id = int.Parse(args[1]);
        var oreOutPut = double.Parse(args[2]);
        var energyRequirement = double.Parse(args[3]);

        var providerType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IHarvester))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == $"{typeName}Harvester");

        var harvester = (IHarvester)Activator.CreateInstance(providerType, new object[] { id, oreOutPut, energyRequirement });

        return harvester;
    }
}