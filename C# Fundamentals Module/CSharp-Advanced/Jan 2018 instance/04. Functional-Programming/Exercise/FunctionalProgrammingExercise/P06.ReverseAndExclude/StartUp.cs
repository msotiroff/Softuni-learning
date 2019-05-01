namespace P06.ReverseAndExclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divisor == 0;
            Func<List<int>, List<int>> removeDivisibleElements = c => c.Where(n => !isDivisible(n)).ToList();

            var result = removeDivisibleElements(numbers);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
