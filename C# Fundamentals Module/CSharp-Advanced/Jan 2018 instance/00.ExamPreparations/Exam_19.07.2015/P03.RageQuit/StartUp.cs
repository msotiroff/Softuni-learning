namespace P03.RageQuit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"(?<word>[^\d]+)(?<count>\d+)";
            var regex = new Regex(pattern);

            string input = Console.ReadLine();

            var matches = regex.Matches(input);

            var builder = new StringBuilder();

            foreach (Match match in matches)
            {
                var word = match.Groups["word"].Value.ToUpper();
                var count = int.Parse(match.Groups["count"].Value);
                
                for (int i = 0; i < count; i++)
                {
                    builder.Append(word);
                }
            }

            var result = builder.ToString();
            var uniqueSymbolsUsed = result.ToCharArray().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {uniqueSymbolsUsed}");
            Console.WriteLine(result);
        }
    }
}
