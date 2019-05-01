using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000.0;
    private const double DurabilityLoseValue = 100.0;
    
    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public double Durability { get; protected set; }

    public void Broke()
    {
        this.Durability -= DurabilityLoseValue;

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

    public override string ToString()
    {
        return this.GetType().Name
            + Environment.NewLine
            + $"Durability: {this.Durability}";
    }
}