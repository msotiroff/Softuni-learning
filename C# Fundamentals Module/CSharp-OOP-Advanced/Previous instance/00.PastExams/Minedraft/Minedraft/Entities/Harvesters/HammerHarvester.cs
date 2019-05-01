public class HammerHarvester : Harvester
{
    private const double EnergieMultiplier = 2.0;
    private const double OreOutputMultiplier = 4.0;

    public HammerHarvester(int id, double oreOutput, double energyRequirement)
        : base(id, oreOutput * OreOutputMultiplier, energyRequirement * EnergieMultiplier)
    {
    }
}
