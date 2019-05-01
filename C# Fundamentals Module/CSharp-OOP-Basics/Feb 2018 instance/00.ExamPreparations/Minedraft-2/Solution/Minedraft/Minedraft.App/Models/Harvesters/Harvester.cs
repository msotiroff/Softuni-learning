using System;

public abstract class Harvester : Entity, IHarvester
{
    private const string RegistrationFailedErrorMsg = "Harvester is not registered, because of it's {0}";

    private const double MinOreOutput = 0;
    private const double MinEnergyRequirement = 0;
    private const double MaxEnergyRequirement = 20_000;

    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
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
            if (value < MinOreOutput)
            {
                throw new ArgumentException(string.Format(RegistrationFailedErrorMsg, nameof(this.OreOutput)));
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            if (value < MinEnergyRequirement || value > MaxEnergyRequirement)
            {
                throw new ArgumentException(string.Format(RegistrationFailedErrorMsg, nameof(this.EnergyRequirement)));
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var result = $"{this.GetType().Name.Replace("Harvester", string.Empty)} Harvester - {this.Id}"
            + Environment.NewLine
            + $"Ore Output: {this.OreOutput}"
            + Environment.NewLine
            + $"Energy Requirement: {this.EnergyRequirement}";

        return result;
    }
}
