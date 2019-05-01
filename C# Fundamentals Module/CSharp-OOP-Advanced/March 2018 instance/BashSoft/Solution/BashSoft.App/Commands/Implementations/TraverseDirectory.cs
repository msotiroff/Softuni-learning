namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using IO.Contracts;

    // Traverse the current directory to the given depth
    [Alias("Ls", "ls")]
    public class TraverseDirectory : BaseCommand
    {
        private readonly IDirectoryManager directoryManager;

        public TraverseDirectory(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            int depth;
            if (this.Data.Length == 0)
            {
                depth = 0;
            }
            else
            {
                depth = int.Parse(this.Data[0]);
            }

            directoryManager.TraverseDirectory(depth);

            return string.Empty;
        }
    }
}
