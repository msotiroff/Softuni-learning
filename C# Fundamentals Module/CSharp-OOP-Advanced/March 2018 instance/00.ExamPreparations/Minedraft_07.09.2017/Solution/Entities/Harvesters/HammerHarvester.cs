public class HammerHarvester : Harvester
{
    private const double EnergyRequirementMultiplier = 2;
    private const double OreOutputMultiplier = 4;

    public HammerHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= OreOutputMultiplier;
        this.EnergyRequirement *= EnergyRequirementMultiplier;
    }
}