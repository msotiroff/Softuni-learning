using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class HarvesterFactory : IHarvesterFactory
{
    public IHarvester GenerateHarvester(IList<string> args)
    {
        // Sonic {id} {oreOutput} {energyRequirement}
        var harvesterSuffix = "Harvester";

        var harvesterType = args[0];
        var id = int.Parse(args[1]);
        var oreOutput = double.Parse(args[2]);
        var energyRequirement = double.Parse(args[3]);

        var instanceType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IHarvester)))
            .FirstOrDefault(t => t.Name.Replace(harvesterSuffix, string.Empty) == harvesterType);

        IHarvester harvester = (IHarvester)Activator.CreateInstance(instanceType, new object[] { id, oreOutput, energyRequirement });

        return harvester;
    }
}
