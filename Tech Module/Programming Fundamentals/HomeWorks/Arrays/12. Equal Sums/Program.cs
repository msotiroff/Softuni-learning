using System;
using System.Linq;

namespace _12.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            
            bool foundEqualSums = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                if (numbers.Length > 1)
                {
                    leftSum = numbers.Take(i).Sum();
                    rightSum = numbers.Skip(i + 1).Take(numbers.Length - 1 - i).Sum();
                    if (leftSum == rightSum)
                    {
                        Console.WriteLine(i);
                        foundEqualSums = true;
                    }
                }
                if (numbers.Length == 1)
                {
                    Console.WriteLine(i);
                    foundEqualSums = true;
                }
                
            }
            if (!foundEqualSums)
            {
                Console.WriteLine("no");
            }

        }
    }
}
