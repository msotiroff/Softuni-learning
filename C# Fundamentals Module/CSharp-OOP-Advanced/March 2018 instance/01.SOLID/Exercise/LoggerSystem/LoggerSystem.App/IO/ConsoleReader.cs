namespace LoggerSystem.App.IO
{
    using Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
