using System;
using System.Collections.Generic;

namespace P01.Fibonacci
{
    public class StartUp
    {
        private static Dictionary<long, long> calculatedFibonaccis;

        public static void Main(string[] args)
        {
            calculatedFibonaccis = new Dictionary<long, long>();

            var n = long.Parse(Console.ReadLine());

            var result = GetFibbonaci(n);

            Console.WriteLine(result);
        }

        private static long GetFibbonaci(long n)
        {
            if (n == 2 || n == 1)
            {
                return 1;
            }

            if (calculatedFibonaccis.ContainsKey(n))
            {
                return calculatedFibonaccis[n];
            }

            var currentFibNumber = GetFibbonaci(n - 1) + GetFibbonaci(n - 2);
            calculatedFibonaccis.Add(n, currentFibNumber);

            return currentFibNumber;
        }
    }
}
