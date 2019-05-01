namespace InfernoInfinity.IO.Implementations
{
    using InfernoInfinity.IO.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
