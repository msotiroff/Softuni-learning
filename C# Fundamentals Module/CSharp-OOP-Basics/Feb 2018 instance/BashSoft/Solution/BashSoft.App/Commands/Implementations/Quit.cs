namespace BashSoft.App.Commands.Implementations
{
    using Contracts;
    using Extensions.CustomAttributes;
    using System;

    [Alias("Quit", "quit")]
    public class Quit : IInterpretable
    {
        public string Interpret(params string[] arguments)
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}
