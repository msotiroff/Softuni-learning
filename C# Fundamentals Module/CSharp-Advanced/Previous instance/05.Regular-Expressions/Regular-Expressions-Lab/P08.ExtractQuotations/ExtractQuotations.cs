namespace P08.ExtractQuotations
{
    using System;
    using System.Text.RegularExpressions;

    public class ExtractQuotations
    {
        public static void Main(string[] args)
        {
            var quotationPattern = "(['\"])(?<Quote>.+?)\\1";

            var regex = new Regex(quotationPattern);

            var text = Console.ReadLine();

            var quotes = regex.Matches(text);

            foreach (Match quote in quotes)
            {
                Console.WriteLine(quote.Groups["Quote"].Value);
            }
        }
    }
}
