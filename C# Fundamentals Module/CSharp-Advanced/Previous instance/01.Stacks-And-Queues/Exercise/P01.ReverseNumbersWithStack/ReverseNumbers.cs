namespace P01.ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var stackOfNumbers = new Stack<int>();

            numbers.ForEach(n => stackOfNumbers.Push(n));

            while (stackOfNumbers.Any())
            {
                Console.Write($"{stackOfNumbers.Pop()} ");
            }

            Console.WriteLine();
        }
    }
}
