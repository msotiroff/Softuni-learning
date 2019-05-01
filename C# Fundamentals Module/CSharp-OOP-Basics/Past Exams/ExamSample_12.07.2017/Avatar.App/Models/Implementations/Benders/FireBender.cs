public class FireBender : Bender
{
    private double heatAggression;

    public double HeatAggression
    {
        get => this.heatAggression;
        private set
        {
            this.heatAggression = value;
        }
    }
    
    public FireBender(string name, double power, double heatAggression)
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public override double TotalPower => base.Power * this.heatAggression;

    public override string ToString()
    {
        return $"Fire Bender: {base.Name}, Power: {base.Power}, Heat Aggression: {this.heatAggression:f2}";
    }
}
