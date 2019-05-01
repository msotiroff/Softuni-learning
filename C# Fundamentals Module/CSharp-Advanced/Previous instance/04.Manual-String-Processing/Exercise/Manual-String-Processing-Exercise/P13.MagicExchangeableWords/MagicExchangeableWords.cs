namespace P13.MagicExchangeableWords
{
    using System;
    using System.Linq;

    public class MagicExchangeableWords
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var firstWord = input[0];
            var secondWord = input[1];

            var result = AreExchangeable(firstWord, secondWord).ToString().ToLower();

            Console.WriteLine(result);
        }

        public static bool AreExchangeable(string firstWord, string secondWord)
        {
            bool exchengable = false;

            var first = firstWord.ToCharArray().Distinct().ToList();
            var second = secondWord.ToCharArray().Distinct().ToList();

            if (first.Count == second.Count)
            {
                exchengable = true;
            }

            return exchengable;
        }
    }
}
