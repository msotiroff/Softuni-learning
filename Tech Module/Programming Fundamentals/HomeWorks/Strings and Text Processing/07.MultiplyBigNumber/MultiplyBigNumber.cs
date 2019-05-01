﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        static void Main(string[] args)
        {
            var firstNumber = Console.ReadLine().ToCharArray().Select(x => x.ToString()).ToList();
            while (firstNumber[0] == "0")
            {
                firstNumber.RemoveAt(0);
            }

            int multiplier = int.Parse(Console.ReadLine());

            string result = string.Empty;
            int rest = 0;

            for (int i = firstNumber.Count - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(firstNumber[i]);
                int currentProduct = currentDigit * multiplier + rest; ;

                rest = 0;

                if (currentProduct > 9)
                {
                    var reminder = currentProduct.ToString().Last();
                    rest = int.Parse(currentProduct.ToString().First().ToString());

                    result += reminder;

                    if (i == 0)
                    {
                        result += rest.ToString();
                    }
                }
                else
                {
                    result += currentProduct;
                }
            }

            string finalResult = string.Empty;

            for (int i = result.Length - 1; i >= 0; i--)
            {
                finalResult += result[i];
            }

            if (finalResult.All(x => x == '0'))
            {
                finalResult = "0";
            }

            Console.WriteLine(finalResult);
        }
    }
}