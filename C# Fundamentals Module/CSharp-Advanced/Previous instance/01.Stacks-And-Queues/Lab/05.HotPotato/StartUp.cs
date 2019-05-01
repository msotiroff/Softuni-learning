namespace _05.HotPotato
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] children = Console.ReadLine()
                .Split()
                .ToArray();

            int step = int.Parse(Console.ReadLine());

            Queue<string> childrenInGame = new Queue<string>(children);

            while (childrenInGame.Count > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    childrenInGame.Enqueue(childrenInGame.Dequeue());
                }

                Console.WriteLine($"Removed {childrenInGame.Dequeue()}");
            }

            Console.WriteLine($"Last is {childrenInGame.Peek()}");
        }
    }
}
