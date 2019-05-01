public class Assassin : AbstractHero
{
    private const int DefaultStrenght = 25;
    private const int DefaultAgility = 100;
    private const int DefaultIntelligence = 15;
    private const int DefaultHitpoints = 150;
    private const int DefaultDamage = 300;

    public Assassin(string name)
        : base(name, DefaultStrenght, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
