public class PowerHardware : Hardware
{
    public PowerHardware(string name, int maxCapacity, int maxMemory) 
        : base(name, maxCapacity, maxMemory)
    {
        this.ChangeParameters();
    }

    protected override void ChangeParameters()
    {
        this.MaxCapacity /= 4;
        this.MaxMemory = this.MaxMemory * 7 / 4;
    }
}
