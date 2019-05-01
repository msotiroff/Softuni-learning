using System;
using System.Numerics;

namespace _11.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factoriel = 1;

            while (n > 1)
            {
                factoriel *= n;
                n--;
            }

            Console.WriteLine(factoriel);
        }
    }
}
