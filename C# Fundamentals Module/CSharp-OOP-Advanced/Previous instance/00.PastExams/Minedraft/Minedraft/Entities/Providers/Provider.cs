public abstract class Provider : IProvider
{
    private const double DefaultDurability = 1000.0;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = DefaultDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= 100.0;
        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}
