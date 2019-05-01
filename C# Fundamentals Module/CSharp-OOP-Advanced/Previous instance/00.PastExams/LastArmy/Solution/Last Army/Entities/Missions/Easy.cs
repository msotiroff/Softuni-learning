public class Easy : Mission
{
    private const double DefaultEnduranceRequired = 20.0;
    private const double DefaultWearDecreaseValue = 30.0;
    private const string DefaultName = "Suppression of civil rebellion";

    public Easy(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearDecreaseValue;
}
