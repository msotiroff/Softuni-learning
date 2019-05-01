namespace BashSoft.App.Commands.Implementations
{
    using BashSoft.App.Repositories;
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;

    [Alias("Order", "order")]
    public class Order : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            if (arguments.Length != 4)
            {
                throw new System.InvalidOperationException(ExceptionMessages.InvalidCommandParams);
            }

            var courseName = arguments[0];
            var orderType = arguments[1].ToLower();
            int studentsToTake;
            int.TryParse(arguments[3].ToLower(), out studentsToTake);

            StudentRepository.OrderAndTake(courseName, orderType, studentsToTake);

            return string.Empty;
        }
    }
}
