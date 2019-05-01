using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;

namespace _04.PunctuationFinder
{
    class PunctuationFinder
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("sample_text.txt");

            char[] punctuations = { '.', ',', '!', '?', ':' };

            List<char> result = new List<char>();
            

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < punctuations.Length; j++)
                {
                    if (text[i] == punctuations[j])
                    {
                       result.Add(text[i]);
                    }
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
