public class MachineGun : Ammunition
{
    private const double DeafaultWeight = 10.6;

    public MachineGun(string name)
        : base(name, DeafaultWeight)
    {
    }
}
