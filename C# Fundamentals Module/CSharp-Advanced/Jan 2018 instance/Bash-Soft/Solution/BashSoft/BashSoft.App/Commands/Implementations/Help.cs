namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("Help", "help")]
    public class Help : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            var helpInfo = IOManager.ReadHelpInfo();

            return helpInfo;
        }
    }
}
