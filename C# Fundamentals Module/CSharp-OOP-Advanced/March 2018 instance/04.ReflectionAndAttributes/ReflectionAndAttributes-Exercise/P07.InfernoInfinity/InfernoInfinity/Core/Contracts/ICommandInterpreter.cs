namespace InfernoInfinity.Core.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] commandParams);
    }
}
