using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftUniCoffeeSupplies
{
    class SoftUniCoffeeSupplies
    {
        static void Main(string[] args)
        {
            //       CoffeeType     drinkers
            Dictionary<string, List<string>> coffeeTypesAndDrinkers = new Dictionary<string, List<string>>();
            //     CoffeeTypes  Quantities
            Dictionary<string, long> coffeeTypesAndQuantities = new Dictionary<string, long>();


            string[] delimiters = Console.ReadLine().Split(' ').ToArray();
            string firstDelimiter = delimiters[0];
            string secondDelimiter = delimiters[1];


            string infoCommand = Console.ReadLine();

            while (infoCommand != "end of info")
            {
                if (infoCommand.Contains(firstDelimiter))
                {
                    string[] currentParameters = infoCommand.Split(new[] { firstDelimiter }, StringSplitOptions.RemoveEmptyEntries);
                    string currentName = currentParameters[0];
                    string currentCofeeType = currentParameters[1];

                    if (!coffeeTypesAndDrinkers.ContainsKey(currentCofeeType))
                    {
                        coffeeTypesAndDrinkers[currentCofeeType] = new List<string>();
                        coffeeTypesAndQuantities[currentCofeeType] = 0;
                    }
                    coffeeTypesAndDrinkers[currentCofeeType].Add(currentName);
                }
                else if (infoCommand.Contains(secondDelimiter))
                {
                    string[] currentParameters = infoCommand.Split(new[] { secondDelimiter }, StringSplitOptions.RemoveEmptyEntries);

                    string currentCofeeType = currentParameters[0];
                    long currentQuantity = long.Parse(currentParameters[1]);

                    if (! coffeeTypesAndQuantities.ContainsKey(currentCofeeType))
                    {
                        coffeeTypesAndQuantities[currentCofeeType] = 0;
                        coffeeTypesAndDrinkers[currentCofeeType] = new List<string>();
                    }
                    coffeeTypesAndQuantities[currentCofeeType] += currentQuantity;
                }



                infoCommand = Console.ReadLine();
            }
            foreach (var type in coffeeTypesAndQuantities.Where(x => x.Value == 0))
            {
                Console.WriteLine($"Out of {type.Key}");
            }

            string drinkCommand = Console.ReadLine();

            while (drinkCommand != "end of week")
            {
                string[] drinkParameters = drinkCommand.Split(' ');
                string currentDrinker = drinkParameters[0];
                long currentDrunkQuantity = long.Parse(drinkParameters[1]);

                foreach (var type in coffeeTypesAndDrinkers)
                {
                    string currCoffeeType = type.Key;
                    if (type.Value.Contains(currentDrinker))
                    {
                        coffeeTypesAndQuantities[currCoffeeType] -= currentDrunkQuantity;
                        if (coffeeTypesAndQuantities[currCoffeeType] <= 0)
                        {
                            Console.WriteLine($"Out of {currCoffeeType}");
                        }
                        break;
                    }
                }



                drinkCommand = Console.ReadLine();
            }
            Dictionary<string, List<string>> onlyAvailableCoffeeTypes = new Dictionary<string, List<string>>();
            Console.WriteLine("Coffee Left:");
            foreach (var coffee in coffeeTypesAndQuantities.Where(x => x.Value > 0).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{coffee.Key} {coffee.Value}");
                onlyAvailableCoffeeTypes.Add(coffee.Key, new List<string>());
            }


            foreach (var type in coffeeTypesAndDrinkers)
            {
                if (onlyAvailableCoffeeTypes.ContainsKey(type.Key))
                {
                    onlyAvailableCoffeeTypes[type.Key].AddRange(type.Value);
                }
            }



            Console.WriteLine("For:");
            foreach (var kvp in onlyAvailableCoffeeTypes.OrderBy(x => x.Key))
            {
                foreach (var drinker in kvp.Value.OrderByDescending(y => y))
                {
                    Console.WriteLine($"{drinker} {kvp.Key}");
                }

            }
        }
    }
}
