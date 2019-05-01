public class PressureProvider : Provider
{
    private const double DurabilityIncreaser = -300.0;
    private const double EnergyMultiplier = 2.0;

    public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput * EnergyMultiplier)
    {
        this.Durability += DurabilityIncreaser;
    }
}
