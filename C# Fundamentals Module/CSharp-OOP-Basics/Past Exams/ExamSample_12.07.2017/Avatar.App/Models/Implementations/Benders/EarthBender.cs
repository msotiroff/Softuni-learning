public class EarthBender : Bender
{
    private double groundSaturation;

    public double GroundSaturation
    {
        get => this.groundSaturation;
        private set
        {
            this.groundSaturation = value;
        }
    }
    
    public EarthBender(string name, double power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public override double TotalPower => base.Power * this.groundSaturation;

    public override string ToString()
    {
        return $"Earth Bender: {base.Name}, Power: {base.Power}, Ground Saturation: {this.groundSaturation:f2}";
    }
}
