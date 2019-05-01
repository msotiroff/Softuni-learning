using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(IHeroManager heroManager, IList<string> arguments) 
        : base(heroManager, arguments)
    {
    }

    public override string Execute()
    {
        var heroName = this.Arguments[0];
        var heroType = this.Arguments[1];

        return this.HeroManager.AddHero(heroName, heroType);
    }
}
