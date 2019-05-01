public class WaterMonument : Monument
{
    private int waterAffinity;

    public int WaterAffinity
    {
        get => this.waterAffinity;
        private set
        {
            this.waterAffinity = value;
        }
    }

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public override double GetAffinity()
    {
        return this.waterAffinity;
    }

    public override string ToString()
    {
        return $"Water Monument: {base.Name}, Water Affinity: {this.waterAffinity}";
    }
}