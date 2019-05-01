namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static Dictionary<string, Dictionary<string, long>> bag;
        public static void Main(string[] args)
        {
            bag = new Dictionary<string, Dictionary<string, long>>()
            {
                ["Gold"] = new Dictionary<string, long>(),
                ["Gem"] = new Dictionary<string, long>(),
                ["Cash"] = new Dictionary<string, long>()
            };

            var bagCapacity = long.Parse(Console.ReadLine());

            long goldSum = 0;
            long gemSum = 0;
            long cashSum = 0;

            var wealths = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < wealths.Length; i += 2)
            {
                var currentWealth = wealths[i];
                var currentAmount = long.Parse(wealths[i + 1]);

                var bagFilling = goldSum + gemSum + cashSum;

                if (IsGold(currentWealth))
                {
                    if (bagFilling + currentAmount <= bagCapacity)
                    {
                        if (!bag["Gold"].ContainsKey(currentWealth))
                        {
                            bag["Gold"][currentWealth] = currentAmount;
                            goldSum += currentAmount;
                        }
                        else
                        {
                            bag["Gold"][currentWealth] += currentAmount;
                            goldSum += currentAmount;
                        }
                    }
                }
                else if (IsGem(currentWealth))
                {
                    if (gemSum + currentAmount <= goldSum
                        && currentAmount + bagFilling <= bagCapacity)
                    {
                        if (!bag["Gem"].ContainsKey(currentWealth))
                        {
                            bag["Gem"][currentWealth] = currentAmount;
                            gemSum += currentAmount;
                        }
                        else
                        {
                            bag["Gem"][currentWealth] += currentAmount;
                            gemSum += currentAmount;
                        }
                    }
                }
                else if (IsCash(currentWealth))
                {
                    if (cashSum + currentAmount <= gemSum
                        && currentAmount + bagFilling <= bagCapacity)
                    {
                        if (!bag["Cash"].ContainsKey(currentWealth))
                        {
                            bag["Cash"][currentWealth] = currentAmount;
                            cashSum += currentAmount;
                        }
                        else
                        {
                            bag["Cash"][currentWealth] += currentAmount;
                            cashSum += currentAmount;
                        }
                    }
                }
            }

            foreach (var wealth in bag.OrderByDescending(i => i.Value.Sum(v => v.Value)))
            {
                if (wealth.Value.Any())
                {
                    Console.WriteLine($"<{wealth.Key}> ${wealth.Value.Sum(v => v.Value)}");

                    foreach (var item in wealth.Value.OrderByDescending(i => i.Key).ThenBy(i => i.Value))
                    {
                        Console.WriteLine($"##{item.Key} - {item.Value}");
                    }
                }
            }
        }

        private static bool IsCash(string wealth)
        {
            return wealth.Length == 3;
        }

        private static bool IsGem(string wealth)
        {
            return wealth.ToLower().EndsWith("gem") && wealth.Length > 3;
        }

        private static bool IsGold(string wealth)
        {
            return wealth.ToLower() == "gold";
        }
    }
}