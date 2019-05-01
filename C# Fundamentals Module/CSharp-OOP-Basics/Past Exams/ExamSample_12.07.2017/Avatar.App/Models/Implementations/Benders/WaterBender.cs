public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, double power, double waterClarity)
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

    public override double TotalPower => base.Power * this.waterClarity;

    public override string ToString()
    {
        return $"Water Bender: {base.Name}, Power: {base.Power}, Water Clarity: {this.waterClarity:f2}";
    }
}
