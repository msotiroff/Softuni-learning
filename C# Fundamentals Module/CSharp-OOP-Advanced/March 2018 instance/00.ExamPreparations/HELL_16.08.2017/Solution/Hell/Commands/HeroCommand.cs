using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    private IHeroManager heroManager;
    private IHeroFactory heroFactory;

    public HeroCommand(IHeroManager heroManager, IHeroFactory heroFactory, IList<string> args) 
        : base(args)
    {
        this.heroManager = heroManager;
        this.heroFactory = heroFactory;
    }

    public override string Execute()
    {
        var heroName = this.Arguments[0];
        var heroType = this.Arguments[1];

        var hero = this.heroFactory.CreateHero(heroName, heroType);

        var result = this.heroManager.AddHero(hero);

        return result;
    }
}
