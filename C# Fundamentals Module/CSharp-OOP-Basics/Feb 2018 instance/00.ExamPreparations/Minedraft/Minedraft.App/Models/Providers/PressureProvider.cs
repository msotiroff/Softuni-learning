public class PressureProvider : Provider
{
    private const double EnergyMultiplier = 0.5;

    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        base.EnergyOutput *= EnergyMultiplier;
    }
}
