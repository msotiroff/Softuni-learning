using System.Collections.Generic;

public class InspectCommand : AbstractCommand
{
    private IHeroManager heroManager;

    public InspectCommand(IHeroManager heroManager, IList<string> args) 
        : base(args)
    {
        this.heroManager = heroManager;
    }

    public override string Execute()
    {
        var heroName = this.Arguments[0];

        var result = this.heroManager.Inspect(heroName);

        return result;
    }
}
