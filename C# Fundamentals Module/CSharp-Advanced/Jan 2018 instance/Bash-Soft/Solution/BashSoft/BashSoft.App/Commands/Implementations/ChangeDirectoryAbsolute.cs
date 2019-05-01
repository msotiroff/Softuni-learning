namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("changeDirAbs")]
    public class ChangeDirectoryAbsolute : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            var absolutePath = arguments[0];

            IOManager.ChangeCurrentDirectoryAbsolute(absolutePath);

            return Constants.AbsolutePathChanged;
        }
    }
}
