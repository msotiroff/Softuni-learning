namespace P03.GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class GreedyTimes
    {
        private static Dictionary<string, Dictionary<string, long>> bag;
        private static long bagCapacity;

        public static void Main(string[] args)
        {
            bag = new Dictionary<string, Dictionary<string, long>>()
            {
                ["Gold"] = new Dictionary<string, long>(),
                ["Gem"] = new Dictionary<string, long>(),
                ["Cash"] = new Dictionary<string, long>()
            };

            bagCapacity = long.Parse(Console.ReadLine());

            var treasures = Console.ReadLine();

            var regex = new Regex(@"(?<item>[A-Za-z]{3,})\s+(?<amount>\d+)");

            var matches = regex.Matches(treasures);
            
            foreach (Match item in matches)
            {
                var currentItem = item.Groups["item"].Value.ToString();
                var itemAmount = long.Parse(item.Groups["amount"].Value.ToString());
                
                if (currentItem.ToLower() == "gold")
                {
                    if (AreRulesComplied("Gold", currentItem, itemAmount))
                    {
                        if (!bag["Gold"].ContainsKey(currentItem))
                        {
                            bag["Gold"][currentItem] = 0;
                        }
                        bag["Gold"][currentItem] += itemAmount;
                    }
                }
                else if (currentItem.Length == 3)
                {
                    if (AreRulesComplied("Cash", currentItem, itemAmount))
                    {
                        if (!bag["Cash"].ContainsKey(currentItem))
                        {
                            bag["Cash"][currentItem] = 0;
                        }
                        bag["Cash"][currentItem] += itemAmount;
                    }
                }
                else if (currentItem.Length > 3 && currentItem.ToLower().EndsWith("gem"))
                {
                    if (AreRulesComplied("Gem", currentItem, itemAmount))
                    {
                        if (!bag["Gem"].ContainsKey(currentItem))
                        {
                            bag["Gem"][currentItem] = 0;
                        }
                        bag["Gem"][currentItem] += itemAmount;
                    }
                }
            }

            foreach (var type in bag)
            {
                if (type.Value.Any())
                {
                    Console.WriteLine($"<{type.Key}> ${type.Value.Sum(t => t.Value)}");
                    foreach (var item in type.Value.OrderByDescending(x => x.Key))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }

        private static bool AreRulesComplied(string itemType, string item, long amount)
        {
            var goldsAmount = bag["Gold"].Sum(g => g.Value);
            var gemsAmount = bag["Gem"].Sum(g => g.Value);
            var cashAmount = bag["Cash"].Sum(c => c.Value);

            var bagFilling = goldsAmount + gemsAmount + cashAmount;

            if (bagFilling + amount > bagCapacity)
            {
                return false;
            }

            if (itemType == "Gold")
            {
                return goldsAmount + amount >= gemsAmount;
            }

            if (itemType == "Gem")
            {
                return gemsAmount + amount <= goldsAmount;
            }

            if (itemType == "Cash")
            {
                return cashAmount + amount <= gemsAmount;
            }

            return false;
        }
    }
}
