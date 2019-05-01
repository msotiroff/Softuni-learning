public class Assassin : AbstractHero
{
    private const long DefaultStrength = 25;
    private const long DefaultAgility = 100;
    private const long DefaultIntelligence = 15;
    private const long DefaultHitpoints = 150;
    private const long DefaultDamage = 300;

    public Assassin(string name)
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
