namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories;

    [Alias("Filter", "filter")]
    public class Filter : IInterpretable
    {
        private readonly StudentRepository studentRepository;

        public Filter(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string Interpret(params string[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 4);
            }

            var courseName = arguments[0];
            var filter = arguments[1].ToLower();
            var studentsToTake = arguments[3];

            studentRepository.FilterAndTake(courseName, filter, studentsToTake);

            return string.Empty;
        }
    }
}
