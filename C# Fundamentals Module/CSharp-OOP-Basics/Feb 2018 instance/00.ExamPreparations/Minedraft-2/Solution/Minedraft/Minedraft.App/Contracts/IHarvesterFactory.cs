using System.Collections.Generic;

public interface IHarvesterFactory
{
    Harvester GenerateHarvester(List<string> arguments);
}
