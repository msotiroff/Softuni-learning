namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("changeDirAbs")]
    public class ChangeDirectoryAbsolute : IInterpretable
    {
        private readonly IOManager iOManager;

        public ChangeDirectoryAbsolute(IOManager iOManager)
        {
            this.iOManager = iOManager;
        }

        public string Interpret(params string[] arguments)
        {
            var absolutePath = arguments[0];

            iOManager.ChangeCurrentDirectoryAbsolute(absolutePath);

            return Constants.AbsolutePathChanged;
        }
    }
}
