using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharRotation
{
    class CharRotation
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();
            int[] inputNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            string result = string.Empty;

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                int currentCharNumber = inputString[i];
                if (inputNumbers[i] % 2 == 0)
                {
                    currentCharNumber -= inputNumbers[i];
                }
                else
                {
                    currentCharNumber += inputNumbers[i];
                }
                char currentChar = (char)(currentCharNumber);
                result += currentChar;
            }

            Console.WriteLine(result);

        }
    }
}
