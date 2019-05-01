using System;
using System.Text;

public abstract class Provider : Worker, IProvider
{
    private double energyOutput;

    public Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var type = this
            .GetType()
            .Name
            .Replace("Provider", string.Empty);

        var result = new StringBuilder()
            .AppendLine($"{type} Provider - {this.Id}")
            .Append($"Energy Output: {this.energyOutput}");

        return result.ToString();
    }
}
