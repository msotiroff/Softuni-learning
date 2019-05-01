using System.Collections.Generic;

public abstract class BaseCommand : ICommand
{
    public IList<string> Arguments { get; }

    protected BaseCommand(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public abstract string Execute();
}
