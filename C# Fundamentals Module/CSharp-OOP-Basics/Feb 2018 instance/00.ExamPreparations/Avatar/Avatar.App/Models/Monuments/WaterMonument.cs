public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int affinity) 
        : base(name)
    {
        this.WaterAffinity = affinity;
    }

    public int WaterAffinity
    {
        get => this.waterAffinity;

        private set
        {
            this.waterAffinity = value;
        }
    }

    public override int GetAffinity()
    {
        return this.waterAffinity;
    }
}
