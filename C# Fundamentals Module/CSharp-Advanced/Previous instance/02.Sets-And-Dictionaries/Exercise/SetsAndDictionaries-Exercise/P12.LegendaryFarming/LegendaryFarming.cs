namespace P12.LegendaryFarming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegendaryFarming
    {
        private static readonly Dictionary<string, string> legendaryItems =
            new Dictionary<string, string>()
            {
                ["shards"] = "Shadowmourne",
                ["fragments"] = "Valanyr",
                ["motes"] = "Dragonwrath"
            };

        public static void Main(string[] args)
        {
            /*
            Shadowmourne – requires 250 Shards;
            Valanyr – requires 250 Fragments;
            Dragonwrath – requires 250 Motes;
             */

            var keyMaterials = new Dictionary<string, int>()
            {
                ["shards"] = 0,
                ["fragments"] = 0,
                ["motes"] = 0
            };

            var junkMaterials = new Dictionary<string, int>();

            var anyKeyMaterialReached = false;
            var reachedMaterial = string.Empty;

            while (!anyKeyMaterialReached)
            {
                // Input format: 3 Motes 5 stones 5 Shards
                var inputLine = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < inputLine.Length; i += 2)
                {
                    var currentQuantity = int.Parse(inputLine[i]);
                    var currentMaterial = inputLine[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(currentMaterial))
                    {
                        keyMaterials[currentMaterial] += currentQuantity;
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(currentMaterial))
                        {
                            junkMaterials[currentMaterial] = 0;
                        }

                        junkMaterials[currentMaterial] += currentQuantity;
                    }

                    if (keyMaterials.Any(km => km.Value >= 250))
                    {
                        anyKeyMaterialReached = true;
                        reachedMaterial = currentMaterial;
                        keyMaterials[reachedMaterial] -= 250;
                        break;
                    }
                }
            }
            
            var legendaryItemBought = legendaryItems[reachedMaterial];

            PrintResult(keyMaterials, junkMaterials, legendaryItemBought);
        }

        private static void PrintResult(Dictionary<string, int> keyMaterials, Dictionary<string, int> junkMaterials, string legendaryItemBought)
        {
            Console.WriteLine($"{legendaryItemBought} obtained!");

            foreach (var keyMaterial in keyMaterials.OrderByDescending(km => km.Value).ThenBy(km => km.Key))
            {
                Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
            }

            foreach (var junkMaterial in junkMaterials.OrderBy(jm => jm.Key))
            {
                Console.WriteLine($"{junkMaterial.Key}: {junkMaterial.Value}");
            }
        }
    }
}
