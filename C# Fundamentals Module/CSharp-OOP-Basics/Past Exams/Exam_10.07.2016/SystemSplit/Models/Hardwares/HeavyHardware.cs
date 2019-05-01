using System;

public class HeavyHardware : Hardware
{
    public HeavyHardware(string name, int maxCapacity, int maxMemory) 
        : base(name, maxCapacity, maxMemory)
    {
        this.ChangeParameters();
    }

    protected override void ChangeParameters()
    {
        this.MaxCapacity *= 2;
        this.MaxMemory = this.MaxMemory * 3 / 4;
    }
}
