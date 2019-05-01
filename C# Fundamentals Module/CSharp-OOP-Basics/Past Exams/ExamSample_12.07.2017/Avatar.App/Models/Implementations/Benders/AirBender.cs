public class AirBender : Bender
{
    private double aerialIntegrity;
    
    public AirBender(string name, double power, double aerialIntegrity) 
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

    public override double TotalPower => base.Power * this.aerialIntegrity;

    public override string ToString()
    {
        return $"Air Bender: {base.Name}, Power: {base.Power}, Aerial Integrity: {this.aerialIntegrity:f2}";
    }
}
