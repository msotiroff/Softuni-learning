public class EarthMonument : Monument
{
    private int earthAffinity;

    public EarthMonument(string name, int affinity) 
        : base(name)
    {
        this.EarthAffinity = affinity;
    }

    public int EarthAffinity
    {
        get => this.earthAffinity;

        private set
        {
            this.earthAffinity = value;
        }
    }

    public override int GetAffinity()
    {
        return this.earthAffinity;
    }
}
