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
        public string Interpret(params string[] arguments)
        {
            var folderName = arguments[0];

            IOManager.CreateDirectoryInCurrentFolder(folderName);

            return string.Format(Constants.DirectoryCreationSuccessful, folderName);
        }
    }
}
