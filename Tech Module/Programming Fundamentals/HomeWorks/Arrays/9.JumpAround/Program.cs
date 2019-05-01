using System;
using System.Linq;

namespace _9.JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            bool posibleMove = true;
            int currentIndex = 0;
            int maxIndex = numbers.Length - 1;

            while (posibleMove)
            {
                int currentValue = numbers[currentIndex];
                sum += currentValue;

                if (currentIndex + currentValue > maxIndex)
                {
                    if (currentIndex - currentValue < 0)
                    {
                        posibleMove = false; ;
                    }
                    else
                    {
                        currentIndex -= currentValue;
                    }
                }
                else
                {
                    currentIndex += currentValue;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
