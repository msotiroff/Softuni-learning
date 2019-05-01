using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Sum__Min__Max__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInput = int.Parse(Console.ReadLine());
            int[] numbers = new int[numberOfInput];

            for (int i = 0; i < numberOfInput; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbers[i] = currentNumber;
            }

            int sum = numbers.Sum();
            int min = numbers.Min();
            int max = numbers.Max();
            double average = numbers.Average();

            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
