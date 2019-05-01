using System;

namespace _2.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            
            Console.WriteLine(IsPrime(n));
        }

        public static bool IsPrime(long number)
        {
            bool prime = true;
            if (number < 2)
            {
                prime = false;
            }
            else
            {
                for (long i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        prime = false;
                    }
                }
            }

            return prime;
        }
    }
}
