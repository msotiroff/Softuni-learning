namespace P03.SeriesOfLetters
{
    using System;
    using System.Text.RegularExpressions;

    public class SeriesOfLetters
    {
        public static void Main(string[] args)
        {
            var pattern = @"(\w)\1+";

            var regex = new Regex(pattern);

            var text = Console.ReadLine();

            text = Regex.Replace(text, pattern, g => g.Groups[1].ToString());

            Console.WriteLine(text);
        }
    }
}
