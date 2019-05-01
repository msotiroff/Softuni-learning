using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstSymbols = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();
            char[] secondSymbols = Console.ReadLine()
                .Split(' ')
                .Select(char.Parse)
                .ToArray();


            string firstWord = string.Join("", firstSymbols);
            string secondWord = string.Join("", secondSymbols);

            int result = string.Compare(firstWord, secondWord);

            if (result <= 0)
            {
                Console.WriteLine(firstWord);
                Console.WriteLine(secondWord);
            }
            else
            {
                Console.WriteLine(secondWord);
                Console.WriteLine(firstWord);
            }

        }
    }
}
