public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        base.EnergyOutput *= 1.5;
    }
}