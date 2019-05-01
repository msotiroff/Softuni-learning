public class HammerHarvester : Harvester
{
    private const double OreOutputMultiplier = 3.0;
    private const double EnergyRequirementMultiplier = 2.0;

    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= OreOutputMultiplier;
        this.EnergyRequirement *= EnergyRequirementMultiplier;
    }
}
