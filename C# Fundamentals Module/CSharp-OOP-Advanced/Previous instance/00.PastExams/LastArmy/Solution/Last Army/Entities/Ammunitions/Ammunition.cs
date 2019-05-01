public abstract class Ammunition : IAmmunition
{
    private const int InitialWearLevelMultiplier = 100;

    public Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = weight * InitialWearLevelMultiplier;
    }

    public string Name { get; }

    public double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}
