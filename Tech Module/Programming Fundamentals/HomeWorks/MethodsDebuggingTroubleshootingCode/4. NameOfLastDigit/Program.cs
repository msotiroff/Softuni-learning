using System;

namespace _4.NameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();

            Console.WriteLine(LastDigitAsWord(inputNumber));
        }
        public static string LastDigitAsWord(string number)
        {
            string last = number[number.Length - 1].ToString();
            int lastDigit = int.Parse(last);
            
            string[] digitsAsWord = 
                { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            return digitsAsWord[lastDigit];
        }
    }
}
