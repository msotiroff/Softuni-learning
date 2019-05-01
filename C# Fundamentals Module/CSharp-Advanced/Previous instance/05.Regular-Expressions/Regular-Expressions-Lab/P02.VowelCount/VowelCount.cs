namespace P02.VowelCount
{
    using System;
    using System.Text.RegularExpressions;

    public class VowelCount
    {
        public static void Main(string[] args)
        {
            var text = Console.ReadLine();

            var pattern = @"[AEIOUYaeiouy]";

            var regex = new Regex(pattern);

            var countOfVowels = regex.Matches(text).Count;

            Console.WriteLine($"Vowels: {countOfVowels}");
        }
    }
}
