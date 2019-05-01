public class HardTyre : Tyre
{
    private const string HardName = "Hard";

    public HardTyre(double hardness) 
        : base(hardness)
    {
        base.Name = HardName;
    }
}
