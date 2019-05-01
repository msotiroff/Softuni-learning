using System;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int year, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, year, horsepower, acceleration, suspension, durability)
    {
    }

    public int Stars { get; private set; }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.Stars += tuneIndex;
    }

    public override string ToString()
    {
        return base.ToString()
            + Environment.NewLine
            + $"{this.Stars} *";
    }
}
