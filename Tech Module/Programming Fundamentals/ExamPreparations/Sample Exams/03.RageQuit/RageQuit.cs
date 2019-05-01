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
            string chochkoInput = Console.ReadLine();

            Regex separateInput = new Regex(@"(.+?)(\d+)");

            var matchedSequences = separateInput.Matches(chochkoInput);

            StringBuilder result = new StringBuilder();

            foreach (Match sequence in matchedSequences)
            {
                string currentSequence = sequence.Groups[1].Value.ToString();
                int numberOfRepeats = int.Parse(sequence.Groups[2].Value.ToString());

                for (int i = 0; i < numberOfRepeats; i++)
                {
                    result.Append(currentSequence.ToUpper());
                }
            }

            var uniqueSymbols = result.ToString().ToCharArray().Distinct();
            int uniqueCount = uniqueSymbols.Count();

            Console.WriteLine($"Unique symbols used: {uniqueCount}");
            Console.WriteLine(result.ToString());
        }
    }
}
