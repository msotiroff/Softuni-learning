public class HammerHarvester : Harvester
{
    private const double OreOutputMultiplier = 3.0;
    private const double EnergyMultiplier = 2.0;


    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput *= OreOutputMultiplier;
        base.EnergyRequirement *= EnergyMultiplier;
    }
}
