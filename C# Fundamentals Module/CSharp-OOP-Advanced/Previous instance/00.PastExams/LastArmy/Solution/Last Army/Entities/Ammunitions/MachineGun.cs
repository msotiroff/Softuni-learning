public class MachineGun : Ammunition
{
    public const double DefaultWeight = 10.6;

    public MachineGun(string name)
        : base(name, DefaultWeight)
    {
    }
}