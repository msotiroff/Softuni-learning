namespace P11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());

            var pesticitides = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var daysToDie = new int[numberOfPlants];

            var alivePlants = new Stack<int>();

            alivePlants.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                int maxDaysToDie = 0;

                while (alivePlants.Count > 0 && pesticitides[alivePlants.Peek()] >= pesticitides[i])
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, daysToDie[alivePlants.Pop()]);
                }

                if (alivePlants.Count > 0)
                {
                    daysToDie[i] = maxDaysToDie + 1;
                }

                alivePlants.Push(i);
            }

            Console.WriteLine(daysToDie.Max());
        }
    }
}
