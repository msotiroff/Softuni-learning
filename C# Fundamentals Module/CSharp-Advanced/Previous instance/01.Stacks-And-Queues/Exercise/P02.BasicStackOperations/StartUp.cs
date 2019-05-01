namespace P02.BasicStackOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var inputParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            var amountOfElementsToPush = inputParams[0];
            var amountOfElementsToPop = inputParams[1];
            var elementToCheck = inputParams[2];

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.ForEach(n => stack.Push(n));

            for (int i = 0; i < amountOfElementsToPop; i++)
            {
                stack.Pop();
            }

            Console.WriteLine(stack.Contains(elementToCheck) ? 
                                                "true" : stack.Any() ?
                                                    stack.Min().ToString() : "0");
        }
    }
}
