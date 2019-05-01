using System;
using System.Numerics;

namespace _4.Big_Factorial
{
    class BigFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factoriel = 1;

            while (n > 0)
            {
                factoriel *= n;
                n--;
            }

            Console.WriteLine(factoriel);
        }
    }
}
