namespace P01.RecursiveArraySum
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var result = Sum(numbers, 0);

            Console.WriteLine(result);
        }

        private static double Sum(double[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                return 0;
            }

            return numbers[index] + Sum(numbers, index + 1);
        }
    }
}
