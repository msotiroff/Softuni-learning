using System.Collections.Generic;

public abstract class BaseCommand : ICommand
{
    public BaseCommand(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments { get; }

    public abstract string Execute();
}
