namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using IO.Contracts;
    using StaticData;

    [Alias("changeDirRel", "cdRel", "cdrel")]
    public class ChangeDirectoryRelative : BaseCommand
    {
        private readonly IDirectoryManager directoryManager;

        public ChangeDirectoryRelative(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            var relativePath = this.Data[0];

            directoryManager.ChangeCurrentDirectoryRelative(relativePath);

            return Constants.RelativePathChanged;
        }
    }
}
