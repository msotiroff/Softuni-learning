public class EarthMonument : Monument
{
    private int earthAffinity;

    public int EarthAffinity
    {
        get => this.earthAffinity;
        private set
        {
            this.earthAffinity = value;
        }
    }

    public EarthMonument(string name, int earthAffinity)
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public override double GetAffinity()
    {
        return this.earthAffinity;
    }

    public override string ToString()
    {
        return $"Earth Monument: {base.Name}, Earth Affinity: {this.earthAffinity}";
    }
}