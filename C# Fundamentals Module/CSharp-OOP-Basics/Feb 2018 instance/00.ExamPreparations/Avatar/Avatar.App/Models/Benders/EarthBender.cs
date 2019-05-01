public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get => this.groundSaturation;

        private set
        {
            this.groundSaturation = value;
        }
    }

    public override double GetSpecialCharacteristic()
    {
        return this.groundSaturation;
    }

    public override string ToString()
    {
        return base.ToString() + $", Ground Saturation: {this.groundSaturation:f2}";
    }
}
