using System;

namespace _8.House_Builder
{
    class HouseBuilder
    {
        static void Main(string[] args)
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());

            long sum = 0;

            if (firstNumber <= 127)
            {
                sum = 4 * firstNumber + 10 * secondNumber;
            }
            else
            {
                sum = 10 * firstNumber + 4 * secondNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
