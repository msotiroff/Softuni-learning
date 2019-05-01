namespace P08.RecursiveFibonacci
{
    using System;
    using System.Collections.Generic;

    public class RecursiveFibonacci
    {
        private static Dictionary<int, long> memory = new Dictionary<int, long>();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long nthFibonacci = GetFibonacci(n);

            Console.WriteLine(nthFibonacci);
        }

        private static long GetFibonacci(int number)
        {
            if (number == 0 || number == 1)
            {
                return number;
            }

            if (memory.ContainsKey(number))
            {
                return memory[number];
            }

            long currentValue = GetFibonacci(number - 2) + GetFibonacci(number - 1);

            memory.Add(number, currentValue);

            return currentValue;
        }
    }
}
