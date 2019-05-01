namespace P09.StackFibonacci
{
    using System;
    using System.Collections.Generic;

    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());

            var fibonacciStack = new Stack<long>();

            fibonacciStack.Push(0);
            fibonacciStack.Push(1);

            for (int i = 0; i < n - 1; i++)
            {
                var lastElement = fibonacciStack.Pop();
                var preLastElement = fibonacciStack.Peek();
                var currentElement = lastElement + preLastElement;

                fibonacciStack.Push(lastElement);
                fibonacciStack.Push(currentElement);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
