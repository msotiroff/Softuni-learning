namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Repositories.Contracts;

    [Alias("ReadDb", "readDb")]
    public class ReadDatabaseFromFile : BaseCommand
    {
        private readonly IDatabase repository;

        public ReadDatabaseFromFile(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            var fileName = this.Data[0];

            repository.LoadData(fileName);

            return string.Empty;
        }
    }
}
