namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories.Contracts;

    [Alias("Filter", "filter")]
    public class Filter : BaseCommand
    {
        private readonly IDatabase repository;

        public Filter(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            if (this.Data.Length != 4)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 4);
            }

            var courseName = this.Data[0];
            var filter = this.Data[1].ToLower();
            var studentsToTake = this.Data[3];

            repository.FilterAndTake(courseName, filter, studentsToTake);

            return string.Empty;
        }
    }
}
