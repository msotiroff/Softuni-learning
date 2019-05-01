using System;

public abstract class Harvester : IHarvester
{
    private const double InitialDurability = 1000;
    private const double DurabilityLoseValue = 100.0;
    
    protected Harvester(int id, double oreOutput, double energyRequirement)
    {
        this.ID = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double OreOutput { get; protected set; }

    public double EnergyRequirement { get; protected set; }

    public double Durability { get; protected set; }

    public virtual void Broke()
    {
        this.Durability -= DurabilityLoseValue;

        if (this.Durability < 0)
        {
            throw new System.ArgumentException();
        }
    }

    public double Produce()
    {
        return this.OreOutput;
    }

    public override string ToString()
    {
        return this.GetType().Name
            + Environment.NewLine
            + $"Durability: {this.Durability}";
    }
}