using System;
using System.Text;

public abstract class Harvester : Worker, IHarvester
{
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(this.EnergyRequirement)}");
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var type = this
            .GetType()
            .Name
            .Replace("Harvester", string.Empty);

        var result = new StringBuilder()
            .AppendLine($"{type} Harvester - {this.Id}")
            .AppendLine($"Ore Output: {this.oreOutput}")
            .Append($"Energy Requirement: {this.energyRequirement}");

        return result.ToString();
    }
}
