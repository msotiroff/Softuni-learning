namespace P05.SequenceWithQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SequenceWithQueue
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            queue.Enqueue(n);

            var numbers = new List<long>();
            numbers.Add(n);

            while (numbers.Count < 50)
            {
                for (long i = 0; i < 3; i++)
                {
                    var currentNumber = queue.Dequeue();
                    long sumOne = currentNumber + 1;
                    long sumTwo = 2 * currentNumber + 1;
                    long sumThree = currentNumber + 2;

                    numbers.Add(sumOne);
                    numbers.Add(sumTwo);
                    numbers.Add(sumThree);

                    queue.Enqueue(sumOne);
                    queue.Enqueue(sumTwo);
                    queue.Enqueue(sumThree);
                }
            }

            var result = numbers.Take(50);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
