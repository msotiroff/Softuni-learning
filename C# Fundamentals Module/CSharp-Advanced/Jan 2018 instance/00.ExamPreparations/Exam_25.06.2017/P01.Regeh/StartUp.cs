namespace P01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var pattern = @"\[[^\[\s]+?<(\d+)REGEH(\d+)>[^\]\s]+?\]";
            var regex = new Regex(pattern);

            var inputLine = Console.ReadLine();

            var indexes = new List<int>();

            var matches = regex.Matches(inputLine);

            foreach (Match match in matches)
            {
                var firstIndex = int.Parse(match.Groups[1].Value);
                var secondIndex = int.Parse(match.Groups[2].Value);

                indexes.Add(firstIndex);
                indexes.Add(secondIndex);
            }

            var result = new StringBuilder();

            var currentIndex = 0;
            foreach (var index in indexes)
            {
                currentIndex += index;
                currentIndex %= inputLine.Length;

                result.Append(inputLine[currentIndex]);
            }

            Console.WriteLine(result);
        }
    }
}
