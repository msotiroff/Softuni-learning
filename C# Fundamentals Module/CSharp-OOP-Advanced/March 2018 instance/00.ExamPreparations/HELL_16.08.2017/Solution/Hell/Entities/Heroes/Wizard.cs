public class Wizard : AbstractHero
{
    private const int DefaultStrenght = 25;
    private const int DefaultAgility = 25;
    private const int DefaultIntelligence = 100;
    private const int DefaultHitpoints = 100;
    private const int DefaultDamage = 250;

    public Wizard(string name) 
        : base(name, DefaultStrenght, DefaultAgility, DefaultIntelligence, DefaultHitpoints, DefaultDamage)
    {
    }
}
