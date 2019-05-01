namespace P04.TowersOfHanoi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static int stepsTaken = 0;

        private static Stack<int> sourse;
        private static Stack<int> spare;
        private static Stack<int> destination;

        public static void Main()
        {
            var numberOfDisks = int.Parse(Console.ReadLine());

            var disks = Enumerable.Range(1, numberOfDisks).Reverse();

            sourse = new Stack<int>(disks);
            spare = new Stack<int>();
            destination = new Stack<int>();

            PrintRods();
            MoveDisks(numberOfDisks, sourse, destination, spare);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> sourse, Stack<int> destination, Stack<int> spare)
        {
            if (bottomDisk == 1)
            {
                var topElement = sourse.Pop();
                destination.Push(topElement);
                Console.WriteLine($"Step #{++stepsTaken}: Moved disk");
                PrintRods();
            }
            else
            {
                // Move disks on the top of bottomDisk from sourse to spare
                MoveDisks(bottomDisk - 1, sourse, spare, destination);


                destination.Push(sourse.Pop());
                Console.WriteLine($"Step #{++stepsTaken}: Moved disk");
                PrintRods();

                // Move disks previously moved to spare to destination
                MoveDisks(bottomDisk - 1, spare, destination, sourse);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine($"Source: {string.Join(", ", sourse.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}
