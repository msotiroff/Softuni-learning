namespace P04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main(string[] args)
        {
            var parameters = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var countOfElementsToEnqueue = parameters[0];
            var countOfElementsToDequeue = parameters[1];
            var neededElement = parameters[2];

            var elements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var numbers = new Queue<int>(elements.Take(countOfElementsToEnqueue));

            for (int i = 0; i < countOfElementsToDequeue; i++)
            {
                numbers.Dequeue();
            }

            Console.WriteLine(numbers.Contains(neededElement)
                ? "true"
                : numbers.Any()
                    ? numbers.Min().ToString()
                    : "0");
        }
    }
}
