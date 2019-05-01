public class Barbarian : AbstractHero
{
    private const long DefaultStrength = 90;
    private const long DefaultAgility = 25;
    private const long DefaultIntelligence = 10;
    private const long DefaultHitpoints = 350;
    private const long DefaultDamage = 150;

    public Barbarian(string name) 
        : base(name, DefaultStrength, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
