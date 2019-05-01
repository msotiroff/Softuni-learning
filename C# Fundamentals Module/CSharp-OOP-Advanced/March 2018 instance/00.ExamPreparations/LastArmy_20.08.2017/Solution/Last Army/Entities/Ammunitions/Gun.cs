public class Gun : Ammunition
{
    private const double DeafaultWeight = 1.4;

    public Gun(string name)
        : base(name, DeafaultWeight)
    {
    }
}
