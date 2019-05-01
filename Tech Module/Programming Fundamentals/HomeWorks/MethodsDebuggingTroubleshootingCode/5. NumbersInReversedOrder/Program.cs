using System;

namespace _5.NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();

            string reverced = RevercedNumber(inputNumber);

            Console.WriteLine(reverced);
        }

        public static string RevercedNumber(string number)
        {
            string numberAsString = number.ToString();
            string result = string.Empty;

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                result += numberAsString[i];
            }
            return result;
        }
    }
}
