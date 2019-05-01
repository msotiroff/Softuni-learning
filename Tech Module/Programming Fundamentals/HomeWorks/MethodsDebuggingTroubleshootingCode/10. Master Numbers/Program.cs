using System;

namespace _10.Master_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (HaveEvenDigit(i) && SumDivisibleToSeven(i) && IsSymetric(i))
                {
                    Console.WriteLine(i);
                }
            }
            
        }
        public static bool HaveEvenDigit (int number)
        {
            bool evenDigit = false;
            
            while (number > 0)
            {
                int currentDigit = number % 10;
                if (currentDigit % 2 == 0)
                {
                    evenDigit = true;
                    break;
                }
                number /= 10;
            }
            return evenDigit;
        }

        public static bool SumDivisibleToSeven (int number)
        {
            bool isSumDivisibleToSeven = false;
            int sum = 0;
            while (number > 0)
            {
                int currentDigit = number % 10;
                sum += currentDigit;
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                isSumDivisibleToSeven = true;
            }
            return isSumDivisibleToSeven;
        }

        public static bool IsSymetric(int number)
        {
            bool isSymetric = false;
            string numberAsString = number.ToString();
            string reversedNumber = string.Empty;
            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                reversedNumber += numberAsString[i];
            }

            if (numberAsString == reversedNumber)
            {
                isSymetric = true;
            }
            return isSymetric;
        }
    }
}
