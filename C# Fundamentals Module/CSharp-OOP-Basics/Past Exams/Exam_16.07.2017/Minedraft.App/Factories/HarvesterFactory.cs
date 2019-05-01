using System.Collections.Generic;

public class HarvesterFactory
{
    public static Harvester CreateInstance(List<string> arguments)
    {
        var harvesterType = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        Harvester harvester = null;

        if (harvesterType == "Sonic")
        {
            var sonicFactor = int.Parse(arguments[4]);
            harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        }
        else if (harvesterType == "Hammer")
        {
            harvester = new HammerHarvester(id, oreOutput, energyRequirement);
        }

        return harvester;
    }
}
