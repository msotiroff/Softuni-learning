using System;

public class FireMonument : Monument
{
    private int fireAffinity;

    public int FireAffinity
    {
        get => this.fireAffinity;
        private set
        {
            this.fireAffinity = value;
        }
    }

    public FireMonument(string name, int fireAffinity)
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public override double GetAffinity()
    {
        return this.fireAffinity;
    }

    public override string ToString()
    {
        return $"Fire Monument: {base.Name}, Fire Affinity: {this.fireAffinity}";
    }
}