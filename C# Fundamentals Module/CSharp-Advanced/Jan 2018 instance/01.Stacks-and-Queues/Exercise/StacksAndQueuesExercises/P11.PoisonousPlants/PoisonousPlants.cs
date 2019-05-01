namespace P11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PoisonousPlants
    {
        private static List<int> plants;

        static void Main(string[] args)
        {
            var initialCountOfPlants = int.Parse(Console.ReadLine());

            plants = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var daysToDie = new int[initialCountOfPlants];

            var alivePlantsIndexes = new Stack<int>();
            alivePlantsIndexes.Push(0);

            for (int i = 1; i < initialCountOfPlants; i++)
            {
                var maxDaysToDie = 0;
                var currentPlant = plants[i];

                while (alivePlantsIndexes.Count > 0 && plants[alivePlantsIndexes.Peek()] >= currentPlant)
                {
                    maxDaysToDie = Math.Max(maxDaysToDie, daysToDie[alivePlantsIndexes.Pop()]);
                }

                if (alivePlantsIndexes.Count > 0)
                {
                    daysToDie[i] = maxDaysToDie + 1;
                }

                alivePlantsIndexes.Push(i);
            }

            Console.WriteLine(daysToDie.Max());
        }
    }
}
