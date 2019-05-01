public class AirBender : Bender
{
    private double aerialIntegrity;

    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity
    {
        get => this.aerialIntegrity;
        private set
        {
            this.aerialIntegrity = value;
        }
    }

    public override double GetSpecialCharacteristic()
    {
        return this.aerialIntegrity;
    }

    public override string ToString()
    {
        return base.ToString() + $", Aerial Integrity: {this.aerialIntegrity:f2}";
    }
}
