using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.WriteToFile
{
    class WriteToFile
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("sample_text.txt");

            Regex textFinder = new Regex(@"[^.,?!:]+");

            var matched = textFinder.Matches(text);

            string result = string.Empty;

            foreach (Match words in matched)
            {
                result += words.ToString();
            }

            File.WriteAllText("output.txt", result);
        }
    }
}
