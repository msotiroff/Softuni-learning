namespace P04.SpecialWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SpecialWords
    {
        public static void Main(string[] args)
        {
            var separators = "()[]<>,-!? ".ToCharArray();

            var specialWords = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .GroupBy(w => w)
                .ToDictionary(w => w.Key, w => 0);

            var wordsInText = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in wordsInText)
            {
                if (specialWords.ContainsKey(word))
                {
                    specialWords[word]++;
                }
            }

            foreach (var word in specialWords)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
