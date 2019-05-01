using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.ExtractSentencesByKeyword
{
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            string keyWord = string.Format(@"\b" + Console.ReadLine() + @"\b");

            string inputText = Console.ReadLine();

            string pattern = @"([A-Z][\w\s,:;]+\W" + keyWord + @"\W.*?)[\.\!\?]{1}";
            Regex allSentences = new Regex(pattern);

            var mathedSentences = allSentences.Matches(inputText);

            foreach (Match sentence in mathedSentences)
            {
                Console.WriteLine(sentence.Groups[1].Value.ToString());
            }

        }
    }
}
