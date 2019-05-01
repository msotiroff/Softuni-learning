namespace BashSoft.App.Commands.Implementations
{
    using BashSoft.App.Commands.Contracts;

    public abstract class BaseCommand : IExecutable
    {
        public BaseCommand(params string[] data)
        {
            this.Data = data;
        }

        public string[] Data { get; }
        
        public abstract string Execute();
    }
}
