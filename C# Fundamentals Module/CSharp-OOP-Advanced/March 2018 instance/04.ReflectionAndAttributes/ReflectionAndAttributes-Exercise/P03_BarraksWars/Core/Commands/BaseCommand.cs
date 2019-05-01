namespace P03_BarraksWars.Core.Commands
{
    using _03BarracksFactory.Contracts;

    public abstract class BaseCommand : IExecutable
    {
        private string[] data;

        protected BaseCommand(string[] data)
        {
            this.Data = data;
        }
        
        protected string[] Data
        {
            get => this.data;
            private set => this.data = value;
        }

        public abstract string Execute();
    }
}
