using System.Collections.Generic;
using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand InterpretCommand(string commandName, IEnumerable<string> arguments);
    }
}