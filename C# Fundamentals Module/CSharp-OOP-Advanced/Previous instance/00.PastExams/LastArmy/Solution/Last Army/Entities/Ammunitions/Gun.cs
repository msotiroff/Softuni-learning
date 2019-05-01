public class Gun : Ammunition
{
    public const double DefaultWeight = 1.4;

    public Gun(string name)
        : base(name, 1.4d)
    {
    }
}
