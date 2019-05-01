using System.Collections.Generic;

public class HarvesterFactory : IHarvesterFactory
{
    public Harvester GenerateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        Harvester harvester = null;

        switch (type)
        {
            case "Sonic":
                var sonicFactor = int.Parse(arguments[4]);
                harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                break;
            case "Hammer":
                harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                break;
            default:
                break;
        }

        return harvester;
    }
}