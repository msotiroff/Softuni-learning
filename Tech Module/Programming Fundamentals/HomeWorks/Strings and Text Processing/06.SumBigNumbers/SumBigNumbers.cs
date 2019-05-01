using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SumBigNumbers
{
    class SumBigNumbers
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToList();
            while (firstNumber[0] == "0")
            {
                firstNumber.RemoveAt(0);
            }
            var secondNumber = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToList();
            while (secondNumber[0] == "0")
            {
                secondNumber.RemoveAt(0);
            }

            int longerNumCountOfDigits = Math.Max(firstNumber.Count, secondNumber.Count);

            while (firstNumber.Count < longerNumCountOfDigits)
            {
                firstNumber.Insert(0, "0");
            }
            while (secondNumber.Count < longerNumCountOfDigits)
            {
                secondNumber.Insert(0, "0");
            }


            string result = string.Empty;

            int rest = 0;

            for (int i = firstNumber.Count - 1; i >= 0; i--)
            {
                int currFirstDigit = int.Parse(firstNumber[i]);
                int currSecondDigit = int.Parse(secondNumber[i]);
                int currentSum = currFirstDigit + currSecondDigit + rest;

                rest = 0;
                
                if (currentSum > 9)
                {
                    var reminder = currentSum.ToString().Last();
                    rest = int.Parse(currentSum.ToString().ToCharArray().First().ToString());
                    result += reminder;
                    if (i == 0)
                    {
                        result += rest.ToString();
                    }
                }
                else
                {
                    result += currentSum.ToString();
                }
            }

            

            string finalResult = string.Empty;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                finalResult += result[i];
            }

            Console.WriteLine(finalResult);
        }
    }
}
