namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using IO;

    // Traverse the current directory to the given depth
    [Alias("Ls", "ls")]
    public class TraverseDirectory : IInterpretable
    {
        private readonly IOManager iOManager;

        public TraverseDirectory(IOManager iOManager)
        {
            this.iOManager = iOManager;
        }

        public string Interpret(params string[] arguments)
        {
            int depth;
            if (arguments.Length == 0)
            {
                depth = 0;
            }
            else
            {
                depth = int.Parse(arguments[0]);
            }

            iOManager.TraverseDirectory(depth);

            return string.Empty;
        }
    }
}
