public class Barbarian : AbstractHero
{
    private const int DefaultStrenght = 90;
    private const int DefaultAgility = 25;
    private const int DefaultIntelligence = 10;
    private const int DefaultHitpoints = 350;
    private const int DefaultDamage = 150;

    public Barbarian(string name)
        : base(name, DefaultStrenght, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
