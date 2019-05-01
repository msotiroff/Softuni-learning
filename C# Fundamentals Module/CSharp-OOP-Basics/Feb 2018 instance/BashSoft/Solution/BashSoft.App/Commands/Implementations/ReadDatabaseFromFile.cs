namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Repositories;

    [Alias("ReadDb", "readDb")]
    public class ReadDatabaseFromFile : IInterpretable
    {
        private readonly StudentRepository studentRepository;

        public ReadDatabaseFromFile(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public string Interpret(params string[] arguments)
        {
            var fileName = arguments[0];

            studentRepository.LoadData(fileName);

            return string.Empty;
        }
    }
}
