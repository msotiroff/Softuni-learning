namespace BashSoft.App.Contracts
{
    using Commands.Contracts;

    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] commandParams);
    }
}
