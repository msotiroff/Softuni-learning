namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Core;
    using Extensions.CustomAttributes;
    using IO;

    // Create a directory in the current directory
    [Alias("Mkdir", "mkdir", "mkDir")]
    public class MakeDirectory : IInterpretable
    {
        private readonly IOManager iOManager;

        public MakeDirectory(IOManager iOManager)
        {
            this.iOManager = iOManager;
        }

        public string Interpret(params string[] arguments)
        {
            var folderName = arguments[0];

            iOManager.CreateDirectoryInCurrentFolder(folderName);

            return string.Format(Constants.DirectoryCreationSuccessful, folderName);
        }
    }
}
