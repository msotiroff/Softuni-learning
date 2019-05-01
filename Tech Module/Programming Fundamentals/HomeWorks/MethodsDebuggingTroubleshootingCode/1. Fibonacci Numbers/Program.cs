using System;

namespace _1.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int nthFibonaccisNumber = Fibonacci(n);

            Console.WriteLine(nthFibonaccisNumber);
        }

        public static int Fibonacci(int n)
        {
            int num1 = 0;
            int num2 = 1;
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result = num1 + num2;
                num1 = num2;
                num2 = result;
            }
            if (n < 2)
            {
                result = 1;
            }
            return result;
        }
    }
}
