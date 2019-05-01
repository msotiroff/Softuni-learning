using System;

namespace _2.Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            PrintResult(name);
        }

        public static void PrintResult(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
