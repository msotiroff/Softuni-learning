using System.Collections.Generic;

public interface ICommandInterpreter
{
    ICommand InterpretCommand(string commandName, IList<string> arguments);
}