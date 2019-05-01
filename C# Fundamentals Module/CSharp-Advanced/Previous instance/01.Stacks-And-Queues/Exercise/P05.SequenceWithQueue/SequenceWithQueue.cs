namespace P05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;

    public class SequenceWithQueue
    {
        public static void Main()
        {
            long number = long.Parse(Console.ReadLine());

            Queue<long> elements = new Queue<long>();
            elements.Enqueue(number);

            for (int i = 0; i < 50; i++)
            {
                elements.Enqueue(elements.Peek() + 1);

                elements.Enqueue(elements.Peek() * 2 + 1);

                elements.Enqueue(elements.Peek() + 2);

                Console.Write(elements.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}
