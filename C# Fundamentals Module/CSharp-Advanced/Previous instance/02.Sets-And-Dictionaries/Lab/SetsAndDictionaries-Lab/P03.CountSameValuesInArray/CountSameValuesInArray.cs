namespace P03.CountSameValuesInArray
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CountSameValuesInArray
    {
        public static void Main(string[] args)
        {
            var counter = new SortedDictionary<double, int>();

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            foreach (var number in numbers)
            {
                if (!counter.ContainsKey(number))
                {
                    counter[number] = 0;
                }

                counter[number]++;
            }

            foreach (var number in counter)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
