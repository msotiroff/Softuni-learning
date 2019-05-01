namespace P07.NChooseKCount
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    class StartUp
    {
        private static Dictionary<KeyValuePair<int, int>, BigInteger> memory;

        static void Main(string[] args)
        {
            memory = new Dictionary<KeyValuePair<int, int>, BigInteger>();

            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var result = Binom(n, k);

            Console.WriteLine(result);
        }

        private static BigInteger Binom(int n, int k)
        {
            var nk = new KeyValuePair<int, int>(n, k);

            if (k > n)
            {
                return 0;
            }
            if (k == 0 || k == n)
            {
                return 1;
            }
            if (memory.ContainsKey(nk))
            {
                return memory[nk];
            }

            memory[nk] = Binom(n - 1, k - 1) + Binom(n - 1, k);
            return memory[nk];
        }
    }
}
