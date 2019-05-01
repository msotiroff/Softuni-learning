public class Hard : Mission
{
    private const double DefaultEnduranceRequired = 80.0;
    private const double DefaultWearDecreaseValue = 70.0;
    private const string DefaultName = "Disposal of terrorists";

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
    }

    public override string Name => DefaultName;

    public override double EnduranceRequired => DefaultEnduranceRequired;

    public override double WearLevelDecrement => DefaultWearDecreaseValue;
}
