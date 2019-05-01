namespace P04.BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BasicQueueOperations
    {
        public static void Main(string[] args)
        {
            var queue = new Queue<int>();

            var inputPrams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var amountOfElementsToEnqueue = inputPrams[0];
            var amountOfElementsToDequeue = inputPrams[1];
            var elementToCheck = inputPrams[2];

            var elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < amountOfElementsToEnqueue; i++)
            {
                queue.Enqueue(elements[i]);
            }

            for (int i = 0; i < amountOfElementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine(queue.Contains(elementToCheck) 
                ? "true" : queue.Any() 
                    ? queue.Min().ToString() : "0");
        }
    }
}
