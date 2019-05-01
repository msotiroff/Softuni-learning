namespace P08.ExtractHyperlinks
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

            var htmlText = builder.ToString();

            var pattern = @"<a([^>]+?)href\s*=\s*(""|'|\s?)(?<Link>.+?)\2(?=\s{1}|>)";

            var hyperLinkExtraxtor = new Regex(pattern);

            var allHyperLinks = hyperLinkExtraxtor.Matches(htmlText);

            foreach (Match link in allHyperLinks)
            {
                Console.WriteLine(link.Groups["Link"].Value.ToString());
            }
        }
    }
}
