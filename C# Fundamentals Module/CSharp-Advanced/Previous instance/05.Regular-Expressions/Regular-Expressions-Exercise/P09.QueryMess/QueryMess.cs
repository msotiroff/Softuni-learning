namespace P09.QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class QueryMess
    {
        public static void Main(string[] args)
        {
            var allPairs = new Dictionary<string, List<string>>();

            var pattern = @"(?<key>[^&?]+)=(?<value>[^&?]+)";

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                allPairs.Clear();

                var currentPairs = Regex.Matches(inputLine, pattern);

                foreach (Match pair in currentPairs)
                {
                    var key = ReduceSpacesInside(pair.Groups["key"].Value.ToString());
                    var value = ReduceSpacesInside(pair.Groups["value"].Value.ToString());

                    if (!allPairs.ContainsKey(key))
                    {
                        allPairs[key] = new List<string>();
                    }
                    if (!allPairs[key].Contains(value))
                    {
                        allPairs[key].Add(value);
                    }
                }

                PrintCurrentPairs(allPairs);
            }
        }

        private static void PrintCurrentPairs(Dictionary<string, List<string>> allPairs)
        {
            foreach (var kvp in allPairs)
            {
                Console.Write($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
            }
            Console.WriteLine();
        }

        private static string ReduceSpacesInside(string item)
        {
            string result = Regex.Replace(item, "(\\+|%20)", " ");
            result = Regex.Replace(result, "\\s+", " ");

            return result.Trim();
        }
    }
}
