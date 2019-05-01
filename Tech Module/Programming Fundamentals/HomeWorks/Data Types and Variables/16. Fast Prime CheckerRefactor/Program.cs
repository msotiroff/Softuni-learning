using System;

namespace _16.Fast_Prime_CheckerRefactor
{
    class FastPrimeCheckerRefactor
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            for (int currentNumber = 2; currentNumber <= number; currentNumber++)
            {
                bool isPrime = true;
                for (int divisor = 2; divisor <= Math.Sqrt(currentNumber); divisor++)
                {
                        if (currentNumber % divisor == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    
                }
                Console.WriteLine($"{currentNumber} -> {isPrime}");
            }
        }
    }
}
