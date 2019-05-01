public class AirMonument : Monument
{
    private int airAffinity;

    public int AirAffinity
    {
        get => this.airAffinity;
        private set
        {
            this.airAffinity = value;
        }
    }
    
    public AirMonument(string name, int airAffinity)
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public override double GetAffinity()
    {
        return this.airAffinity;
    }

    public override string ToString()
    {
        return $"Air Monument: {base.Name}, Air Affinity: {this.airAffinity}";
    }
}