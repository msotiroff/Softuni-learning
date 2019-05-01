namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories.Contracts;

    [Alias("Show", "show")]
    public class Show : BaseCommand
    {
        private readonly IDatabase repository;

        public Show(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            if (this.Data.Length < 1 || this.Data.Length > 2)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 1);
            }

            var courseName = this.Data[0];
            string studentName = null;
            if (this.Data.Length > 1)
            {
                studentName = this.Data[1];
            }
            var studentRepo = (IStudentRepository)repository;

            studentRepo.ShowData(courseName, studentName);

            return string.Empty;
        }
    }
}