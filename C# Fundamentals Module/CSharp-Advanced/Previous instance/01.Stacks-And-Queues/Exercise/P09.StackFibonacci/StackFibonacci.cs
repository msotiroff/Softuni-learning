using System;
using System.Collections.Generic;

namespace P09.StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main(string[] args)
        {
            int nthFibonacci = int.Parse(Console.ReadLine());

            ulong result = GetNthFibonacci(nthFibonacci);

            Console.WriteLine(result);
        }

        private static ulong GetNthFibonacci(int nthFibonacci)
        {
            var fibonacciSequence = new Stack<ulong>();

            fibonacciSequence.Push(0);
            fibonacciSequence.Push(1);

            ulong firstAddend = 0;
            ulong secondAddend = 1;

            for (int i = 0; i < nthFibonacci - 1; i++)
            {
                fibonacciSequence.Push(firstAddend + secondAddend);
                firstAddend = secondAddend;
                secondAddend = fibonacciSequence.Peek();
            }

            return fibonacciSequence.Peek();
        }
    }
}
