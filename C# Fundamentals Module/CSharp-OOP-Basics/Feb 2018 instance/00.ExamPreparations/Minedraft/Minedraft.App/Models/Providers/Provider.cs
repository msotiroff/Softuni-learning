using System;

public abstract class Provider : MiningMachine
{
    private const string ErrorMessage = "Provider is not registered, because of it's {0}";
    
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10_000)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(this.EnergyOutput)));
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var providerTypeName = this.GetType().Name.Replace("Provider", string.Empty);

        return $"{providerTypeName} Provider - {this.Id}" + Environment.NewLine
            + $"Energy Output: {this.energyOutput}";
    }
}
