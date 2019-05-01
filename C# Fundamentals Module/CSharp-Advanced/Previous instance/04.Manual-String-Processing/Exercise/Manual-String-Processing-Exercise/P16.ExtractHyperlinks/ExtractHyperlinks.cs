namespace P16.ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractHyperlinks
    {
        public static void Main(string[] args)
        {
            var builder = new StringBuilder();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                builder.Append(inputLine);
            }

            var wholeHtmlText = builder.ToString();

            var pattern = @"<a([^>]+?)href\s*=\s*(""|'|\s?)(?<HypLink>.+?)\2(?=\s{1}|>)";

            var matches = Regex.Matches(wholeHtmlText, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match.Groups["HypLink"]);
            }
        }
    }
}
