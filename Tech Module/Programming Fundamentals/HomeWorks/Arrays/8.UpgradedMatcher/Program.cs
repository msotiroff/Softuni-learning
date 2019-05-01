using System;
using System.Linq;

namespace _8.UpgradedMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();

            long[] quantities = new long[products.Length];

            long[] givenQuantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            for (int i = 0; i < givenQuantities.Length; i++)
            {
                quantities[i] = givenQuantities[i];
            }

            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            string currentOrder = Console.ReadLine();

            while (currentOrder != "done")
            {
                string[] ordered = currentOrder.Split(' ').ToArray();
                string orderedProduct = ordered[0];
                long orderedQuantity = long.Parse(ordered[1]);

                int neededIndex = Array.IndexOf(products, orderedProduct);

                if (quantities[neededIndex] < orderedQuantity)
                {
                    Console.WriteLine($"We do not have enough {orderedProduct}");
                }
                else
                {
                    decimal currentBill = prices[neededIndex] * orderedQuantity;
                    Console.WriteLine($"{orderedProduct} x {orderedQuantity} costs {currentBill:f2}");
                    quantities[neededIndex] -= orderedQuantity;
                }

                currentOrder = Console.ReadLine();
            }
        }
    }
}
