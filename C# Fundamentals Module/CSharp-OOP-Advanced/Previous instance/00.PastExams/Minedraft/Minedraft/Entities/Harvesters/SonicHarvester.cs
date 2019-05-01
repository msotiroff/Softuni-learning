public class SonicHarvester : Harvester
{
    private const double EnergyDivider = 2.0;
    private const double DurabilityIncreaser = -300.0;

    public SonicHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement / EnergyDivider)
    {
        this.Durability += DurabilityIncreaser;
    }
}
