public class Hard : Mission
{
    private const double DefaultWearLevelDecrement = 70;
    private const double DefaultEnduranceRequired = 80;
    private const string DefauitName = "Disposal of terrorists";

    public Hard(double scoreToComplete)
        : base(DefauitName, DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}

