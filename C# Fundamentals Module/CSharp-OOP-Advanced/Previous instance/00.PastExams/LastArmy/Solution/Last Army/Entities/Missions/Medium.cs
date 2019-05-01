public class Medium : Mission
{
    private const double DefaultEnduranceRequired = 50.0;
    private const double DefaultWearDecreaseValue = 50.0;
    private const string DefaultName = "Capturing dangerous criminals";

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearDecreaseValue;
}
