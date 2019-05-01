using System;
using System.Collections.Generic;
using System.Linq;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int year, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, year, horsepower, acceleration, suspension, durability)
    {
        this.Horsepower = base.Horsepower * 15 / 10;
        this.Suspension = base.Suspension * 3 / 4;
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
        var addOns = this.AddOns.Any() 
            ? string.Join(", ", this.AddOns) 
            : "None";

        return base.ToString()
            + Environment.NewLine
            + $"Add-ons: {addOns}";
    }
}
