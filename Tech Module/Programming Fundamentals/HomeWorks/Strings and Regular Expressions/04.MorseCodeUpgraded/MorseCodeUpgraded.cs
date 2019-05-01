using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.MorseCodeUpgraded
{
    class MorseCodeUpgraded
    {
        static void Main(string[] args)
        {
            string[] allCodes = Console.ReadLine().Split('|').ToArray();

            Regex getSequences = new Regex(@"0{2,}|1{2,}");

            string result = string.Empty;

            for (int i = 0; i < allCodes.Length; i++)
            {
                string currentCode = allCodes[i];
                int currCodeAmount = 0;
                for (int j = 0; j < currentCode.Length; j++)
                {
                    if (currentCode[j] == '0')
                    {
                        currCodeAmount += 3;
                    }
                    else if (currentCode[j] == '1')
                    {
                        currCodeAmount += 5;
                    }
                }

                var matchedSequences = getSequences.Matches(currentCode);

                foreach (Match sequence in matchedSequences)
                {
                    currCodeAmount += sequence.Length;
                }

                if (currCodeAmount == 110 && result.EndsWith("\\"))
                {
                    result += "\\";
                }
                result += (char)currCodeAmount;

            }

            Console.WriteLine(result);

        }
    }
}
