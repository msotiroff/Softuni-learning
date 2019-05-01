using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.MagicExchangeableWords
{
    class MagicExchangeableWords
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            string firstWord = input[0];
            string secondWord = input[1];

            bool result = AreExchangeable(firstWord, secondWord);

            Console.WriteLine(result.ToString().ToLower());
        }

        public static bool AreExchangeable(string firstWord, string secondWord)
        {
            bool exchengable = false;

            List<char> first = firstWord.ToCharArray().Distinct().ToList();
            List<char> second = secondWord.ToCharArray().Distinct().ToList();

            if (first.Count == second.Count)
            {
                exchengable = true;
            }

            return exchengable;
        }
    }
}
