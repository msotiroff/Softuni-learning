using System;
using System.Numerics;
using System.Linq;

namespace _02.ConvertBaseNTobase10
{
    class ConvertBaseNTobase10
    {
        static void Main(string[] args)
        {
            BigInteger[] input = Console.ReadLine()
                .Split(' ')
                .Select(BigInteger.Parse)
                .ToArray();

            BigInteger baseN = input[0];
            BigInteger numberToConvert = input[1];
            
            string number = numberToConvert.ToString();

            BigInteger result = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currDigit = int.Parse(number[i].ToString());

                BigInteger poweredNumber = 1;
                for (int j = 1; j < number.Length - i; j++)
                {
                    poweredNumber *= baseN;
                }

                poweredNumber *= currDigit;

                result += poweredNumber;
            }

            

            Console.WriteLine(result);
        }
    }
}
