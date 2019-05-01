using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Sieve_of_Eratosthenes___2
{
    class Program
    {
        static void Main(string[] args)
        {

            // The real algorithm of Eratosthenes:

            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n + 1];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (numbers[i] != 0)
                {
                    bool prime = true;
                    for (int divider = 2; divider < Math.Sqrt(numbers[i]); divider++)
                    {
                        if (numbers[i] % divider == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime)
                    {
                        for (int toremove = i; toremove < numbers.Length; toremove += i)
                        {
                            numbers[toremove] = 0;
                        }
                        numbers[i] = i;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers.Where(x => x > 1)));
        }
    }
}
