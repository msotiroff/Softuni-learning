using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.DragonArmy
{
    class DragonArmy
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, List<double>>> allDragons =
                new Dictionary<string, SortedDictionary<string, List<double>>>();
            // Dragon Properties:
            // [0] -> Damage
            // [1] -> Health
            // [2] -> Armor

            int numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                string currentDragonType = input[0];
                string currentDragonName = input[1];
                double currentDragonDamage;
                double currentDragonHealth;
                double currentDragonArmor;

                GetDragonProperties(input, out currentDragonDamage, out currentDragonHealth, out currentDragonArmor);

                if (!allDragons.ContainsKey(currentDragonType))
                {
                    allDragons[currentDragonType] = new SortedDictionary<string, List<double>>();
                }
                if (!allDragons[currentDragonType].ContainsKey(currentDragonName))
                {
                    allDragons[currentDragonType][currentDragonName] = new List<double>();
                    allDragons[currentDragonType][currentDragonName].Add(0);
                    allDragons[currentDragonType][currentDragonName].Add(0);
                    allDragons[currentDragonType][currentDragonName].Add(0);
                }

                allDragons[currentDragonType][currentDragonName][0] = currentDragonDamage;
                allDragons[currentDragonType][currentDragonName][1] = currentDragonHealth;
                allDragons[currentDragonType][currentDragonName][2] = currentDragonArmor;

            }


            foreach (var dragonData in allDragons)
            {
                double averageDamage = dragonData.Value.Select(x => x.Value[0]).Average();
                double averageHealths = dragonData.Value.Select(x => x.Value[1]).Average();
                double averageArmor = dragonData.Value.Select(x => x.Value[2]).Average();

                Console.WriteLine($"{dragonData.Key}::({averageDamage:f2}/{averageHealths:f2}/{averageArmor:f2})");

                foreach (var currentDragon in dragonData.Value)
                {
                    // Example:      -Bazgargal -> damage: 100, health: 2500, armor: 25
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        currentDragon.Key,
                        currentDragon.Value[0],
                        currentDragon.Value[1],
                        currentDragon.Value[2]
                        );
                }

            }

        }

        public static void GetDragonProperties(string[] input, out double currentDragonDamage, out double currentDragonHealth, out double currentDragonArmor)
        {
            if (input[2] == "null")
            {
                currentDragonDamage = 45;
            }
            else
            {
                currentDragonDamage = double.Parse(input[2]);
            }

            if (input[3] == "null")
            {
                currentDragonHealth = 250;
            }
            else
            {
                currentDragonHealth = double.Parse(input[3]);
            }
            if (input[4] == "null")
            {
                currentDragonArmor = 10;
            }
            else
            {
                currentDragonArmor = double.Parse(input[4]);
            }
        }
    }
}
