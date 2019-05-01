namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories;

    [Alias("Show", "show")]
    public class Show : IInterpretable
    {
        private readonly StudentRepository studentRepository;

        public Show(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string Interpret(params string[] arguments)
        {
            if (arguments.Length < 1 || arguments.Length > 2)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 1);
            }

            studentRepository.ShowWantedData(arguments);

            return string.Empty;
        }
    }
}