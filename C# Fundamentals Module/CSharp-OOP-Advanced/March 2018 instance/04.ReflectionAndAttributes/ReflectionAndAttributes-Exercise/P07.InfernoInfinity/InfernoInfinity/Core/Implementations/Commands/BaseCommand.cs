namespace InfernoInfinity.Core.Implementations.Commands
{
    using InfernoInfinity.Core.Contracts;

    public abstract class BaseCommand : IExecutable
    {
        protected BaseCommand(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data { get; private set; }

        public abstract string Execute();
    }
}
