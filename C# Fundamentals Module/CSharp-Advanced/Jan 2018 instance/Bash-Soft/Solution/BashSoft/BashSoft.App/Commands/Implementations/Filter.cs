namespace BashSoft.App.Commands.Implementations
{
    using Core;
    using Contracts;
    using Repositories;
    using Extensions.CustomAttributes;

    [Alias("Filter", "filter")]
    public class Filter : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new System.InvalidOperationException(ExceptionMessages.InvalidCommandParams);
            }

            var courseName = arguments[0];
            var filter = arguments[1].ToLower();

            int studentsToTake;
            int.TryParse(arguments[3], out studentsToTake);

            StudentRepository.FilterAndTake(courseName, filter, studentsToTake);

            return string.Empty;
        }
    }
}
