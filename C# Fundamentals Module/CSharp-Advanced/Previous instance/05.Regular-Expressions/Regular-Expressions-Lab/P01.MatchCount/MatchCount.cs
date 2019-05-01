namespace P01.MatchCount
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchCount
    {
        public static void Main(string[] args)
        {
            var searchedWord = Console.ReadLine();

            var text = Console.ReadLine();

            var pattern = searchedWord;

            var regex = new Regex(pattern);

            var count = regex.Matches(text).Count;

            Console.WriteLine(count);
        }
    }
}
