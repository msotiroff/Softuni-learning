using System;
using System.Collections.Generic;
using System.Text;

namespace _03.UnicodeCharacters
{
    class UnicodeCharacters
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Encoding unicode = Encoding.UTF8;

            List<string> results = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentSymbol = input[i];

                var currResult = string.Format("\\u{0:x4}", (int)currentSymbol);

                results.Add(currResult);
            }


            Console.WriteLine(string.Join("", results));
        }
    }
}
