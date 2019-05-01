public class ShowCar : Car
{
    public ShowCar(string brand, string model, int year, int horsePower, int acceleration, int suspension, int durability) 
        : base(brand, model, year, horsePower, acceleration, suspension, durability)
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
        string result = base.ToString() + $"{this.Stars} *";

        return result;
    }
}
