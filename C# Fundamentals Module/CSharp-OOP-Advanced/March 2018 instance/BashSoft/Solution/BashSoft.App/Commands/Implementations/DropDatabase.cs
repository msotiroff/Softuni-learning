namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomExceptions;
    using Repositories.Contracts;
    using StaticData;

    public class DropDatabase : BaseCommand
    {
        private readonly IDatabase repository;

        public DropDatabase(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            if (this.Data.Length != 0)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 0);
            }

            this.repository.UnloadData();

            return Constants.DataUnloaded;
        }
    }
}
