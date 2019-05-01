public class FireMonument : Monument
{
    private int fireAffinity;

    public FireMonument(string name, int affinity) 
        : base(name)
    {
        this.FireAffinity = affinity;
    }

    public int FireAffinity
    {
        get => this.fireAffinity;

        private set
        {
            this.fireAffinity = value;
        }
    }

    public override int GetAffinity()
    {
        return this.fireAffinity;
    }
}
