namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using TeamBuilder.Client.Utilities;

    public static class ExitCommand
    {
        public static string Execute(string[] inputArgs)
        {
            Check.CheckLenght(0, inputArgs);
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
