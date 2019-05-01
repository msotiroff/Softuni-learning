using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string chochkoInput = Console.ReadLine().ToUpper();

            Regex delimite = new Regex(@"(\D+)(\d+)");

            var matched = delimite.Matches(chochkoInput);

            StringBuilder result = new StringBuilder();

            foreach (Match pairs in matched)
            {
                string currentWord = pairs.Groups[1].Value;
                int repeat = int.Parse(pairs.Groups[2].Value);

                for (int i = 0; i < repeat; i++)
                {
                    result.Append(currentWord);
                }
            }

            string realResult = result.ToString();

            Console.WriteLine($"Unique symbols used: {realResult.ToCharArray().Distinct().ToArray().Length}");
            Console.WriteLine(realResult);
        }
    }
}
