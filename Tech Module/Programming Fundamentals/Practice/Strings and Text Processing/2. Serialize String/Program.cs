using System;
using System.Collections.Generic;

namespace _2.Serialize_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Dictionary<char, List<int>> symbolsCount = new Dictionary<char, List<int>>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                char currentSymbol = inputLine[i];

                if (! symbolsCount.ContainsKey(currentSymbol))
                {
                    symbolsCount[currentSymbol] = new List<int>();
                }

                symbolsCount[currentSymbol].Add(i);
            }
            
            foreach (var symbols in symbolsCount)
            {
                Console.Write($"{symbols.Key}:");
                Console.WriteLine(string.Join("/", symbols.Value));
            }
        }
    }
}
