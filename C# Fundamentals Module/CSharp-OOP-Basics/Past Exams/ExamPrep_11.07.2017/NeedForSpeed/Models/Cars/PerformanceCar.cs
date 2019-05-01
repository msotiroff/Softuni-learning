using System.Collections.Generic;
using System.Linq;

public class PerformanceCar : Car
{
    private const double IncreaseHorsePowerMultiplier = 0.5;
    private const double DecreaseSuspensionMultiplier = 0.25;

    public PerformanceCar(string brand, string model, int year, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, year, horsePower, acceleration, suspension, durability)
    {
        base.HorsePower += (int)(base.HorsePower * IncreaseHorsePowerMultiplier);
        base.Suspension -= (int)(base.Suspension * DecreaseSuspensionMultiplier);
        this.AddOns = new List<string>();
    }

    public IList<string> AddOns { get; private set; }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);

        this.AddOns.Add(addOn);
    }

    public override string ToString()
    {
        string addOnsViewModel = this.AddOns.Any() ? string.Join(", ", this.AddOns) : "None";

        var result = base.ToString() + $"Add-ons: {addOnsViewModel}";

        return result;
    }
}
