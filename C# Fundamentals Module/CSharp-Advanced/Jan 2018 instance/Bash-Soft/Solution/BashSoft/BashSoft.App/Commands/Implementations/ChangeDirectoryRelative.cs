namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using IO;

    [Alias("changeDirRel")]
    public class ChangeDirectoryRelative : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            var relativePath = arguments[0];

            IOManager.ChangeCurrentDirectoryRelative(relativePath);

            return Constants.RelativePathChanged;
        }
    }
}
