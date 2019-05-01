using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
    public QuitCommand(IHeroManager heroManager, IList<string> arguments) 
        : base(heroManager, arguments)
    {
    }

    public override string Execute()
    {
        return this.HeroManager.Quit();
    }
}