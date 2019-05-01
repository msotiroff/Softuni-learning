namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Repositories;

    [Alias("Show", "show")]
    public class Show : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            StudentRepository.ShowWantedData(arguments);

            return string.Empty;
        }
    }
}