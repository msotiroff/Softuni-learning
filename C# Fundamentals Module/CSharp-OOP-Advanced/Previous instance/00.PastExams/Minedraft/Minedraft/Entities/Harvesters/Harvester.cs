public abstract class Harvester : IHarvester
{
    private const double DefaultDurability = 1000.0;

    public Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.EnergyRequirement = energyRequirement;
        this.OreOutput = oreOutput;
        this.Durability = DefaultDurability;
    }

    public int ID { get; }

    public double OreOutput { get; }

    public double EnergyRequirement { get; }

    public double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= 100;
        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }
}
