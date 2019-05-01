namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using IO.Contracts;
    using StaticData;

    [Alias("Mkdir", "mkdir", "mkDir")]
    public class MakeDirectory : BaseCommand
    {
        private readonly IDirectoryManager directoryManager;

        public MakeDirectory(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            var folderName = this.Data[0];

            directoryManager.CreateDirectoryInCurrentFolder(folderName);

            return string.Format(Constants.DirectoryCreationSuccessful, folderName);
        }
    }
}
