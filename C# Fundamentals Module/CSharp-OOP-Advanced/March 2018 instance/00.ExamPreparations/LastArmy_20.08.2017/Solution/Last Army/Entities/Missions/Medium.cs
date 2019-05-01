public class Medium : Mission
{
    private const double DefaultWearLevelDecrement = 50;
    private const double DefaultEnduranceRequired = 50;
    private const string DefauitName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete)
        : base(DefauitName, DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}

