namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using SimpleJudge;

    [Alias("Cmp", "cmp")]
    public class CompareFiles : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            if (arguments.Length == 2)
            {
                var firstPath = arguments[0];
                var secondPath = arguments[1];

                var tester = new Tester();

                tester.CompareContent(firstPath, secondPath);

                return string.Empty;
            }

            return Constants.InvalidArguments;
        }
    }
}
