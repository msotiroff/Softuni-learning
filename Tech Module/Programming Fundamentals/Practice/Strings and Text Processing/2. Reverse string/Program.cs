using System;

namespace _2.Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string revercedInput = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                revercedInput += input[i];
            }

            Console.WriteLine(revercedInput);
        }
    }
}
