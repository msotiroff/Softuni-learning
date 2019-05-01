using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.ByteFlip
{
    class ByteFlip
    {
        static void Main(string[] args)
        {
            List<string> inputLine = Console.ReadLine().Split(' ').ToList();

            string result = string.Empty;


            var resultCollection = inputLine
                .Where(x => x.Length == 2)
                .Reverse()
                .ToList();

            for (int i = 0; i < resultCollection.Count; i++)
            {
                char firstSymbol = resultCollection[i][0];
                char secondSymbol = resultCollection[i][1];

                resultCollection[i] = secondSymbol.ToString() + firstSymbol.ToString();

                int number = Convert.ToInt32(resultCollection[i], 16);
                char currentSymbolToAdd = Convert.ToChar(number);
                result += currentSymbolToAdd;
            }
            


            Console.WriteLine(result);
        }
    }
}
