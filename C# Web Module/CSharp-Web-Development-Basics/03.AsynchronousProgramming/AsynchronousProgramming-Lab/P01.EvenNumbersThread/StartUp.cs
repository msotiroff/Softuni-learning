namespace P01.EvenNumbersThread
{
    using System;
    using System.Linq;
    using System.Threading;

    public class StartUp
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var start = range[0];
            var end = range[1];

            var evens = new Thread(() =>
            {
                PrintEvenNumbers(start, end);
            });

            evens.Start();
            evens.Join();

            Console.WriteLine("Thread has finished work");
        }

        private static void PrintEvenNumbers(int start, int end)
        {
            var arrayOfEvenNums = Enumerable
                .Range(start, end)
                .Where(n => n % 2 == 0);

            Console.WriteLine(string.Join(Environment.NewLine, arrayOfEvenNums));
        }
    }
}
