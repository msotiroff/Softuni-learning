using System;

public abstract class Harvester : MiningMachine
{
    private const string ErrorMessage = "Harvester is not registered, because of it's {0}";
    
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;

        protected set
        {
            if (value < 0 || value > 20_000)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(EnergyRequirement)));
            }

            this.energyRequirement = value;
        }
    }
    
    public double OreOutput
    {
        get => this.oreOutput;

        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(string.Format(ErrorMessage, nameof(OreOutput)));
            }

            this.oreOutput = value;
        }
    }

    public override string ToString()
    {
        var harvesterTypeName = this.GetType().Name.Replace("Harvester", string.Empty);

        var result = $"{harvesterTypeName} Harvester - {this.Id}" + Environment.NewLine
            + $"Ore Output: {this.oreOutput}" + Environment.NewLine
            + $"Energy Requirement: {this.energyRequirement}";

        return result;
    }
}
