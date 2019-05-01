namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using Repositories;

    [Alias("Order", "order")]
    public class Order : IInterpretable
    {
        private readonly StudentRepository studentRepository;

        public Order(StudentRepository studentRepository)
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
            var orderType = arguments[1].ToLower();
            var studentsToTake = arguments[3].ToLower();

            studentRepository.OrderAndTake(courseName, orderType, studentsToTake);

            return string.Empty;
        }
    }
}
