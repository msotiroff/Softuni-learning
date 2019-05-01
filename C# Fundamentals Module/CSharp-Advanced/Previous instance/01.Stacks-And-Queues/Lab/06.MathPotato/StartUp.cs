namespace _06.MathPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] children = Console.ReadLine()
                .Split()
                .ToArray();

            int step = int.Parse(Console.ReadLine());
            int cicle = 1;

            Queue<string> childrenInGame = new Queue<string>(children);

            while (childrenInGame.Count > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    childrenInGame.Enqueue(childrenInGame.Dequeue());
                }

                if (IsPrime(cicle))
                {
                    Console.WriteLine($"Prime {childrenInGame.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {childrenInGame.Dequeue()}");
                }
                
                cicle++;
            }

            Console.WriteLine($"Last is {childrenInGame.Peek()}");
        }

        private static bool IsPrime(int number)
        {
            if (number == 1)
            {
                return false;
            }

            bool result = true;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
