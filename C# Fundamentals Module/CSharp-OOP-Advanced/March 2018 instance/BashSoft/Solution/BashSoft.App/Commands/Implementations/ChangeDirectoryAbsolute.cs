namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using IO.Contracts;
    using StaticData;

    [Alias("changeDirAbs", "cdAbs", "cdabs")]
    public class ChangeDirectoryAbsolute : BaseCommand
    {
        private readonly IDirectoryManager directoryManager;

        public ChangeDirectoryAbsolute(string[] data)
            : base(data)
        {
        }
        
        public override string Execute()
        {
            var absolutePath = this.Data[0];

            directoryManager.ChangeCurrentDirectoryAbsolute(absolutePath);

            return Constants.AbsolutePathChanged;
        }
    }
}
