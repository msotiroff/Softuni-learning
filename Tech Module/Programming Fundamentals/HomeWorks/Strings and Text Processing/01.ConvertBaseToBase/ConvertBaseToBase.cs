using System;
using System.Numerics;
using System.Linq;

namespace _01.ConvertBaseToBase
{
    class ConvertBaseToBase
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine()
                .Split(' ')
                .Select(BigInteger.Parse)
                .ToArray();
            string result = string.Empty;

            BigInteger baseN = input[0]; // 2 <= N <= 10
            BigInteger numberToConvert = input[1];

            string preResult = string.Empty;
            BigInteger reminder = 0;

            while (numberToConvert > 0)
            {
                reminder = numberToConvert % baseN;
                numberToConvert /= baseN;
                preResult += reminder.ToString();
            }

            for (int i = preResult.Length - 1; i >= 0; i--)
            {
                result += preResult[i];
            }


            Console.WriteLine(result);
        }
    }
}
