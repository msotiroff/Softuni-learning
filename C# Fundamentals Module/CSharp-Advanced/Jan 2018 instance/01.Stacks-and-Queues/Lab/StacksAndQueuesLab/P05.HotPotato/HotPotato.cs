namespace P05.HotPotato
{
    using System;
    using System.Collections.Generic;

    class HotPotato
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var step = int.Parse(Console.ReadLine());

            var players = new Queue<string>(inputLine);

            while (players.Count > 1)
            {
                for (int i = 1; i < step; i++)
                {
                    players.Enqueue(players.Dequeue());
                }

                Console.WriteLine($"Removed {players.Dequeue()}");
            }

            Console.WriteLine($"Last is {players.Peek()}");
        }
    }
}
