using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.Be_Positive
{
    class Program
    {
        static void Main(string[] args)
        {
            int countSequences = int.Parse(Console.ReadLine());

            for (int i = 0; i < countSequences; i++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                List<int> currentCollectionForPrint = new List<int>();

                for (int j = 0; j < inputNumbers.Length; j++)
                {
                    int currentNumber = inputNumbers[j];
                    if (currentNumber < 0)
                    {
                        if (j < inputNumbers.Length - 1)
                        {
                            currentNumber += inputNumbers[j + 1];
                            j++;
                            if (currentNumber >= 0)
                            {
                                currentCollectionForPrint.Add(currentNumber);
                            }
                        }
                    }
                    else
                    {
                        currentCollectionForPrint.Add(currentNumber);
                    }
                }

                if (currentCollectionForPrint.Count > 0)
                {
                    Console.WriteLine(string.Join(" ", currentCollectionForPrint));
                }
                else
                {
                    Console.WriteLine("(empty)");
                }
            }

        }
    }
}
