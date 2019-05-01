public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int affinity) 
        : base(name)
    {
        this.AirAffinity = affinity;
    }

    public int AirAffinity
    {
        get => this.airAffinity;

        private set
        {
            this.airAffinity = value;
        }
    }

    public override int GetAffinity()
    {
        return this.airAffinity;
    }
}
