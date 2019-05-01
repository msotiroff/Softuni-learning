using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.Happiness_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string happyPattern = @":\)|\:D|;\)|:\*|:]|;]|:}|;}|\(:|\*:|c:|\[:|\[;";
            string sadPattern = @":\(|D:|;\(|:\[|;\[|:{|;{|\):|:c|:c|];|]:";
            
            Regex searchHappy = new Regex(happyPattern);
            Regex searchSad = new Regex(sadPattern);

            var matchedHappy = searchHappy.Matches(inputLine);
            var matchedSad = searchSad.Matches(inputLine);

            int happyCount = matchedHappy.Count;
            int sadCount = matchedSad.Count;

            double happyIndex = (double)happyCount / sadCount;

            string emotionScore = string.Empty;
            if (happyIndex < 1)
            {
                emotionScore = ":(";
            }
            else if (happyIndex == 1)
            {
                emotionScore = ":|";
            }
            else if (happyIndex < 2)
            {
                emotionScore = ":)";
            }
            else if (happyIndex >= 2)
            {
                emotionScore = ":D";
            }


            Console.WriteLine($"Happiness index: {happyIndex:f2} {emotionScore}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }
    }
}
