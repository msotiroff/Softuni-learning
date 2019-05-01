namespace P02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicStackOperations
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var elementsToPush = parameters[0];
            var elementsToPop = parameters[1];
            var neededElement = parameters[2];

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>(numbers);

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            Console.WriteLine(stack.Contains(neededElement)
                                ? "true"
                                : stack.Any()
                                    ? stack.Min().ToString()
                                    : "0");
        }
    }
}
