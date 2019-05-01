namespace BashSoft.App.Commands.Implementations
{
    using Extensions.CustomAttributes;
    using System;

    [Alias("Quit", "quit")]
    public class Quit : BaseCommand
    {
        public Quit(string[] data)
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty; // <- this line will never be reached
        }
    }
}
