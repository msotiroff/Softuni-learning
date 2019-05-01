using System.Collections.Generic;

public interface ICommandInterpreter
{
    ICommand GetCommand(string commandName, IList<string> arguments);
}
