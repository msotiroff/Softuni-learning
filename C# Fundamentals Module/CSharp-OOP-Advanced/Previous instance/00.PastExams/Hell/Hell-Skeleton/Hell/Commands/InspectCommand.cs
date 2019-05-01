using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    public InspectCommand(IHeroManager heroManager, IList<string> arguments)
        : base(heroManager, arguments)
    {
    }

    public override string Execute()
    {
        var heroName = this.Arguments[0];

        return this.HeroManager.Inspect(heroName);
    }
}
