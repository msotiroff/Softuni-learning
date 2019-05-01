using System;
using System.Text.RegularExpressions;

namespace _05.KeyReplacer
{
    class KeyReplacer
    {
        static void Main(string[] args)
        {
            string inputKeys = Console.ReadLine();
            string inputText = Console.ReadLine();

            Regex getStartKey = new Regex(@"(^[A-Za-z]+)[\\\|<]");
            Regex getEndKey = new Regex(@"[\\\|<]([A-Za-z]+$)");

            string startKey = getStartKey.Match(inputKeys).Groups[1].Value.ToString();
            string endKey = getEndKey.Match(inputKeys).Groups[1].Value.ToString();

            string extractorPattern = startKey + @"(.*?){1}" + endKey;
            Regex textExtractor = new Regex(extractorPattern);
            
            var matchedText = textExtractor.Matches(inputText);

            string result = string.Empty;

            foreach (Match text in matchedText)
            {
                result += text.Groups[1].Value.ToString();
            }

            Console.WriteLine(result.Length > 0 ? result : "Empty result");
        }
    }
}
