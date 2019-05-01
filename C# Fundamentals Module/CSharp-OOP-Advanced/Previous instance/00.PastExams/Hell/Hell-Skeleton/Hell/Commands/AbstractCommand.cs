using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    public AbstractCommand(IHeroManager heroManager, IList<string> arguments)
    {
        this.Arguments = arguments;
        this.HeroManager = heroManager;
    }

    protected IList<string> Arguments { get; }

    protected IHeroManager HeroManager { get; }

    public abstract string Execute();
}