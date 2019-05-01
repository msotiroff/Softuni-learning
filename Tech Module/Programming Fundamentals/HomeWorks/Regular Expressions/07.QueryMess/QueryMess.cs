using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _07.QueryMess
{
    class QueryMess
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> allPairs = new Dictionary<string, List<string>>();

            Regex takeKVPs = new Regex(@"(?<key>[^&?]+)=(?<value>[^&?]+)");

            string inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var matches = takeKVPs.Matches(inputLine);

                foreach (Match currentMatch in matches)
                {
                    string currentKey = GetValidKey(currentMatch);
                    string currentValue = GetValidValue(currentMatch);

                    if (!allPairs.ContainsKey(currentKey))
                    {
                        allPairs[currentKey] = new List<string>();
                    }
                    if (!allPairs[currentKey].Contains(currentValue))
                    {
                        allPairs[currentKey].Add(currentValue);
                    }
                }

                PrintCurrentResult(allPairs);

                inputLine = Console.ReadLine();
            }



        }

        public static void PrintCurrentResult(Dictionary<string, List<string>> allPairs)
        {
            foreach (var kvp in allPairs)
            {
                Console.Write($"{kvp.Key}=[{string.Join(", ", kvp.Value)}]");
            }
            Console.WriteLine();

            allPairs.Clear();
        }

        public static string GetValidValue(Match currentMatch)
        {
            string currentValue = currentMatch.Groups["value"].Value.ToString();
            currentValue = Regex.Replace(currentValue, @"%20|\+", " ");
            currentValue = Regex.Replace(currentValue, @"\s+", " ");
            currentValue = currentValue.Trim();

            return currentValue;
        }

        public static string GetValidKey(Match currentMatch)
        {
            string currentKey = currentMatch.Groups["key"].Value.ToString();
            currentKey = Regex.Replace(currentKey, @"%20|\+", " ");
            currentKey = Regex.Replace(currentKey, @"\s+", " ");
            currentKey = currentKey.Trim();

            return currentKey;
        }
    }
}
