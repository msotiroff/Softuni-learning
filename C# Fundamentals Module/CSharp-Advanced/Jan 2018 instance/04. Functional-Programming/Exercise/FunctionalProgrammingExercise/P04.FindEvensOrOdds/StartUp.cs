namespace P04.FindEvensOrOdds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Predicate<int> isOdd = n => n % 2 != 0;
            Predicate<int> isEven = n => n % 2 == 0;

            var range = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbers = FillNumbersInRange(range);

            var command = Console.ReadLine();

            switch (command)
            {
                case "odd":
                    Console.WriteLine(string.Join(" ", numbers.Where(n => isOdd(n))));
                    break;
                case "even":
                    Console.WriteLine(string.Join(" ", numbers.Where(n => isEven(n))));
                    break;
                default:
                    break;
            }
        }

        private static int[] FillNumbersInRange(int[] range)
        {
            var numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            return numbers.ToArray();
        }
    }
}
