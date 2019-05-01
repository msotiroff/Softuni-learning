namespace P02.RecursiveFactorial
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var result = Factoriel(n);

            Console.WriteLine(result);
        }

        private static long Factoriel(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factoriel(n - 1);
        }
    }
}
