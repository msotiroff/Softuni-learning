namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories.Contracts;

    [Alias("Order", "order")]
    public class Order : BaseCommand
    {
        private readonly IDatabase repository;

        public Order(string[] data)
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
            var orderType = this.Data[1].ToLower();
            var studentsToTake = this.Data[3].ToLower();

            repository.OrderAndTake(courseName, orderType, studentsToTake);

            return string.Empty;
        }
    }
}
