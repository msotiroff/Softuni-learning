namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using IO;

    // Traverse the current directory to the given depth
    [Alias("Ls", "ls")]
    public class TraverseDirectory : IInterpretable
    {
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

            IOManager.TraverseDirectory(depth);

            return string.Empty;
        }
    }
}
