public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get => this.waterClarity;

        private set
        {
            this.waterClarity = value;
        }
    }

    public override double GetSpecialCharacteristic()
    {
        return this.waterClarity;
    }

    public override string ToString()
    {
        return base.ToString() + $", Water Clarity: {this.waterClarity:f2}";
    }
}
