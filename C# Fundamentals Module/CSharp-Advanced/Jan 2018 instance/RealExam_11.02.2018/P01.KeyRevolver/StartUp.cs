namespace P01.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var priceOfBullet = int.Parse(Console.ReadLine());

            var initialGunBarrelSize = int.Parse(Console.ReadLine());

            var bullets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToStack();

            var locks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToQueue();

            var intelligenceValue = int.Parse(Console.ReadLine());

            var gunSize = initialGunBarrelSize;

            while (bullets.Count > 0 && locks.Count() > 0)
            {
                var currentBullet = bullets.Pop();
                var currentLock = locks.Peek();

                intelligenceValue -= priceOfBullet;
                gunSize--;

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (gunSize == 0 && bullets.Count != 0)
                {
                    gunSize = initialGunBarrelSize;
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue}");
            }
            else if (bullets.Count == 0 && locks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }

    internal static class CollectionExtensions
    {
        public static Stack<T> ToStack<T> (this IEnumerable<T> collection)
        {
            return new Stack<T>(collection);
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> collection)
        {
            return new Queue<T>(collection);
        }
    }
}
