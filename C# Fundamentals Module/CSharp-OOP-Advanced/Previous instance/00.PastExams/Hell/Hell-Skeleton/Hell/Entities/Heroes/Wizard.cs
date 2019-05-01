public class Wizard : AbstractHero
{
    private const long DefaultStrength = 25;
    private const long DefaultAgility = 25;
    private const long DefaultIntelligence = 100;
    private const long DefaultHitpoints = 100;
    private const long DefaultDamage = 250;

    public Wizard(string name)
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
