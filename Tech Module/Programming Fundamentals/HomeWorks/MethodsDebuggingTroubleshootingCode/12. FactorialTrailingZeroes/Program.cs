using System;
using System.Numerics;

namespace _12.FactorialTrailingZeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorielN = GetFactoriel(n);

            int zeroesAtEnd = GetZeroes(factorielN);

            Console.WriteLine(zeroesAtEnd);

        }

        public static int GetZeroes(BigInteger factoriel)
        {
            int countOfZeroes = 0;

            while (factoriel % 10 == 0)
            {
                BigInteger currentDigit = factoriel % 10;
                if (currentDigit == 0)
                {
                    countOfZeroes++;
                }
                factoriel /= 10;
            }

            return countOfZeroes;
        }

        public static BigInteger GetFactoriel(int n)
        {
            BigInteger factoriel = 1;

            while (n > 1)
            {
                factoriel *= n;
                n--;
            }

            return factoriel;
        }
    }
}
