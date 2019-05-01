using System;
using System.Linq;

namespace _9.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] timesFrequent = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                int counter = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                    }
                }
                timesFrequent[i] = counter;
            }

            int maxCounter = timesFrequent.Max();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (timesFrequent[i] == maxCounter)
                {
                    Console.WriteLine(numbers[i]);
                    break;
                }
            }
        }
    }
}
