using System;
using System.Linq;

namespace _7.Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] products = Console.ReadLine().Split(' ').ToArray();

            long[] quantities = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            decimal[] prices = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();

            string currentProduct = Console.ReadLine();

            while (currentProduct != "done")
            {
                int neededIndex = Array.IndexOf(products, currentProduct);

                long currentQuantity = quantities[neededIndex];

                decimal currentPrice = prices[neededIndex];

                Console.WriteLine($"{currentProduct} costs: {currentPrice}; Available quantity: {currentQuantity}");

                currentProduct = Console.ReadLine();
            }



        }
    }
}
