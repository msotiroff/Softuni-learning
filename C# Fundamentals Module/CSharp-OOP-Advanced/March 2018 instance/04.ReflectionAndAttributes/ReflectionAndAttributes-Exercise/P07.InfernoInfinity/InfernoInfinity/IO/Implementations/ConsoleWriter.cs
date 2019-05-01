namespace InfernoInfinity.IO.Implementations
{
    using InfernoInfinity.IO.Contracts;
    using System;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }
    }
}
