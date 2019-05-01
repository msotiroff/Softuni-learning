namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomExceptions;
    using Repositories;

    public class DropDatabase : IInterpretable
    {
        private readonly StudentRepository studentRepository;

        public DropDatabase(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string Interpret(params string[] arguments)
        {
            if (arguments.Length != 0)
            {
                throw new InvalidCommandArgumentsException(this.GetType().Name, 0);
            }

            this.studentRepository.UnloadData();

            return Constants.DataUnloaded;
        }
    }
}
