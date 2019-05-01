using System;
using System.Collections.Generic;

namespace _3.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            long startNumber = long.Parse(Console.ReadLine());
            long endNumber = long.Parse(Console.ReadLine());

            List<long> primes = FindPrimesInRange(startNumber, endNumber);

            PrintPrimeNumbers(primes);

        }

        public static void PrintPrimeNumbers(List<long> primes)
        {
            Console.WriteLine(string.Join(", ", primes));
        }

        public static List<long> FindPrimesInRange(long startNumber, long endNumber)
        {
            List<long> primeNumbers = new List<long>();

            

            for (long i = startNumber; i <= endNumber; i++)
            {
                bool prime = true;
                if (i < 2)
                {
                    prime = false;
                }
                else
                {
                    for (long divider = 2; divider <= Math.Sqrt(i); divider++)
                    {
                        if (i % divider == 0)
                        {
                            prime = false;
                        }
                    }
                }

                if (prime)
                {
                    primeNumbers.Add(i);
                }
            }

            return primeNumbers;
        }
    }
}
