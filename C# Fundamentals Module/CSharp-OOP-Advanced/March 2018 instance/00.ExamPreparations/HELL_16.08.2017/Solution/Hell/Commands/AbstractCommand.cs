using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    protected AbstractCommand(IList<string> args)
    {
        this.Arguments = args;
    }

    protected IList<string> Arguments { get; }

    public abstract string Execute();
}