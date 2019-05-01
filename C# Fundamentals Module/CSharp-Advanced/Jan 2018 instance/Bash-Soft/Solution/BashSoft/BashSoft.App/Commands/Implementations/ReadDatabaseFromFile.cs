namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Repositories;

    [Alias("ReadDb", "readDb")]
    public class ReadDatabaseFromFile : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            var fileName = arguments[0];

            StudentRepository.InitializeData(fileName);

            return string.Empty;
        }
    }
}
