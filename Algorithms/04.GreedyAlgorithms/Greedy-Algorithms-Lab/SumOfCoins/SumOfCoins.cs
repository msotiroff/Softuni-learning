namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumOfCoins
    {
        public static void Main(string[] args)
        {
            var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
            var targetSum = 923;

            var selectedCoins = ChooseCoins(availableCoins, targetSum);

            Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
            foreach (var selectedCoin in selectedCoins)
            {
                Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();
            var availableCoins = coins
                .OrderByDescending(c => c)
                .ToList();

            for (int coinIndex = 0; coinIndex < availableCoins.Count; coinIndex++)
            {
                var currentCoin = availableCoins[coinIndex];

                result[currentCoin] = targetSum / currentCoin;
                targetSum -= currentCoin * result[currentCoin];

                if (targetSum == 0)
                {
                    break;
                }
            }

            result = result
                .Where(c => c.Value != 0)
                .ToDictionary(x => x.Key, x => x.Value);

            if (targetSum != 0)
            {
                throw new InvalidOperationException("Cannot reach desired sum with these coin values");
            }

            return result;
        }
    }
}