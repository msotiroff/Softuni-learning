using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    private IHeroManager heroManager;

    public QuitCommand(IHeroManager heroManager, IList<string> args) 
        : base(args)
    {
        this.heroManager = heroManager;
    }

    public override string Execute()
    {
        var result = this.heroManager.GenerateResult();

        return result;
    }
}