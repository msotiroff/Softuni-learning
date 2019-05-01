using System;

namespace _09.Make_a_Word
{
    class MakeAWord
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string word = string.Empty;

            for (int i = 0; i < n; i++)
            {
                char currentSymbol = char.Parse(Console.ReadLine());
                word += currentSymbol;
            }

            Console.WriteLine($"The word is: {word}");
        }
    }
}
