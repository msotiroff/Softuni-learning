namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("changeDirRel")]
    public class ChangeDirectoryRelative : IInterpretable
    {
        private readonly IOManager iOManager;

        public ChangeDirectoryRelative(IOManager iOManager)
        {
            this.iOManager = iOManager;
        }

        public string Interpret(params string[] arguments)
        {
            var relativePath = arguments[0];

            iOManager.ChangeCurrentDirectoryRelative(relativePath);

            return Constants.RelativePathChanged;
        }
    }
}
