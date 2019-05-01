namespace P04.CountSymbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSymbols
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            var counter = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentCharacter = input[i];

                if (!counter.ContainsKey(currentCharacter))
                {
                    counter[currentCharacter] = 0;
                }

                counter[currentCharacter]++;
            }

            foreach (var character in counter.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{character.Key}: {character.Value} time/s");
            }
        }
    }
}
