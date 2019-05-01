namespace P01.Regeh
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main(string[] args)
        {
            var result = new StringBuilder();

            var inputLine = Console.ReadLine();

            var pattern = @"\[[^[\s]+?<(?<firstNumber>\d+)REGEH(?<secondNumber>\d+)>[^]\s]+?\]";

            var matches = Regex.Matches(inputLine, pattern);

            var summedIndex = 0;

            foreach (Match match in matches)
            {
                var firstIndex = int.Parse(match.Groups["firstNumber"].Value.ToString());
                summedIndex += firstIndex;

                var symbolToAppend = inputLine[summedIndex % inputLine.Length];
                result.Append(symbolToAppend);
                

                var secondIndex = int.Parse(match.Groups["secondNumber"].Value.ToString());
                summedIndex += secondIndex;
                
                symbolToAppend = inputLine[summedIndex % inputLine.Length];
                result.Append(symbolToAppend);
            }

            Console.WriteLine(result);
        }
    }
}
