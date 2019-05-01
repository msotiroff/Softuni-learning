public class SonicHarvester : Harvester
{
    private const double EnergyRequirementDivider = 2;
    private const double DurabilityLoss = 300;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement /= EnergyRequirementDivider;
        this.Durability -= DurabilityLoss;
    }
}