public class Easy : Mission
{
    private const double DefaultWearLevelDecrement = 30;
    private const double DefaultEnduranceRequired = 20;
    private const string DefaultName = "Suppression of civil rebellion";

    public Easy(double scoreToComplete) 
        : base(DefaultName, DefaultEnduranceRequired, scoreToComplete)
    {
    }

    public override double WearLevelDecrement => DefaultWearLevelDecrement;
}
