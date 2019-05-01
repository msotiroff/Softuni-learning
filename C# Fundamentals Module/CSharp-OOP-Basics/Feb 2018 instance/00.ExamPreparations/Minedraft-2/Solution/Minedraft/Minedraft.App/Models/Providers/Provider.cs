using System;

public abstract class Provider : Entity, IProvider
{
    private const string RegistrationFailedErrorMsg = "Provider is not registered, because of it's {0}";

    private const double MinEnergyOutput = 0;
    private const double MaxEnergyOutput = 10_000;

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
            if (value < MinEnergyOutput || value >= MaxEnergyOutput)
            {
                throw new ArgumentException(string.Format(RegistrationFailedErrorMsg, nameof(this.EnergyOutput)));
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var result = $"{this.GetType().Name.Replace("Provider", string.Empty)} Provider - {this.Id}"
            + Environment.NewLine
            + $"Energy Output: {this.EnergyOutput}";

        return result;
    }
}
