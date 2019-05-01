using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {

            // NOT the real algorithm of Eratosthenes:
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, bool> primeOrNot = new Dictionary<int, bool>();

            for (int i = 2; i <= n; i++)
            {
                primeOrNot.Add(i, true);
                for (int divider = 2; divider <= Math.Sqrt(i); divider++)
                {
                    if (i % divider == 0)
                    {
                        primeOrNot[i] = false;
                    }
                }
            }
            primeOrNot[2] = true;

            foreach (var number in primeOrNot.Where(x => x.Value == true))
            {
                Console.Write(number.Key + " ");
            }
            Console.WriteLine();
        }
    }
}
