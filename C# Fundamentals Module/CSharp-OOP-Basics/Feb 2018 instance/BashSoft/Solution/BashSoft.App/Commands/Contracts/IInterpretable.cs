namespace BashSoft.App.Commands.Contracts
{
    public interface IInterpretable
    {
        string Interpret(params string[] arguments);
    }
}
