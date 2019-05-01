using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.TakeSkipRope
{
    class TakeSkipRope
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<int> numberList = new List<int>();

            List<int> takeList = new List<int>();

            List<int> skipList = new List<int>();

            List<string> nonNumberList = new List<string>();

            // Distribute all symbols from input to numberList and wordToProcess
            for (int i = 0; i < inputLine.Length; i++)
            {
                char currentSymbol = inputLine[i];

                if (char.IsDigit(currentSymbol))
                {
                    numberList.Add(int.Parse(currentSymbol.ToString()));
                }
                else
                {
                    nonNumberList.Add(currentSymbol.ToString());
                }
            }

            // Split numberList to two new lists: takeList and skipList
            for (int i = 0; i < numberList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numberList[i]);
                }
                else
                {
                    skipList.Add(numberList[i]);
                }
            }
            
            string result = string.Empty;
            int skipped = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                var currentTokenAsList = nonNumberList.Skip(skipped).Take(takeList[i]).ToList();

                for (int j = 0; j < currentTokenAsList.Count; j++)
                {
                    result += currentTokenAsList[j];
                }

                skipped += skipList[i] + takeList[i];
            }


            Console.WriteLine(result);
        }
    }
}
