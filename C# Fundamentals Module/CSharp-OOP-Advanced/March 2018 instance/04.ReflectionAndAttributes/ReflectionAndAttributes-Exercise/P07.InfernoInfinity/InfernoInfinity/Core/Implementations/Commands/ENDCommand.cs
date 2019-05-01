namespace InfernoInfinity.Core.Implementations.Commands
{
    using System;

    public class ENDCommand : BaseCommand
    {
        public ENDCommand(string[] data) 
            : base(data)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
