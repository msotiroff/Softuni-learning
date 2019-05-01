namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("Help", "help")]
    public class Help : IInterpretable
    {
        private readonly IOManager iOManager;

        public Help(IOManager iOManager)
        {
            this.iOManager = iOManager;
        }

        public string Interpret(params string[] arguments)
        {
            var helpInfo = iOManager.ReadHelpInfo();

            return helpInfo;
        }
    }
}
