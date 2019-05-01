using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Pyramidic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[] inputStrings = new string[n];

            for (int i = 0; i < n; i++)
            {
                string currentInput = Console.ReadLine();
                inputStrings[i] = currentInput;
            }

            List<string> biggestPyramid = new List<string>();

            for (int i = 0; i < inputStrings.Length; i++)
            {
                string currentString = inputStrings[i];

                for (int j = 0; j < currentString.Length; j++)
                {
                    char currentSymbol = currentString[j];
                    int symbolCounter = 1;
                    List<string> currentPyramid = new List<string>();

                    for (int k = i; k < inputStrings.Length; k++)
                    {
                        string neededSequence = new string(currentSymbol, symbolCounter);
                        if (inputStrings[k].Contains(neededSequence))
                        {
                            currentPyramid.Add(neededSequence);
                            symbolCounter += 2;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (currentPyramid.Count > biggestPyramid.Count)
                    {
                        biggestPyramid = currentPyramid.ToList();
                    }
                }
                
            }

            Console.WriteLine(string.Join(Environment.NewLine, biggestPyramid));
        }
    }
}
