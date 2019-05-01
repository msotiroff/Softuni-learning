using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Exam_Shopping
{
    class ExamShopping
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> shopStock = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "shopping" && input[1] != "time")
            {
                StockingTheShop(shopStock, input);

                input = Console.ReadLine().Split(' ').ToArray();
            }

            input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "exam" && input[1] != "time")
            {
                BuyingProducts(shopStock, input);

                input = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var product in shopStock)
            {
                if (product.Value > 0)
                {
                    Console.WriteLine($"{product.Key} -> {product.Value}");
                }
            }
        }

        public static void BuyingProducts(Dictionary<string, int> shopStock, string[] input)
        {
            string product = input[1];
            int buyingQuantity = int.Parse(input[2]);

            if (shopStock.Keys.Contains(product))
            {
                if (buyingQuantity <= shopStock[product])
                {
                    shopStock[product] -= buyingQuantity;
                }
                else
                {
                    if (shopStock[product] == 0)
                    {
                        Console.WriteLine($"{product} out of stock");
                    }
                    else
                    {
                        shopStock[product] = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{product} doesn't exist");
            }
        }

        public static void StockingTheShop(Dictionary<string, int> shopStock, string[] input)
        {
            string product = input[1];
            int quantity = int.Parse(input[2]);

            if (!shopStock.Keys.Contains(product))
            {
                shopStock[product] = quantity;
            }
            else
            {
                shopStock[product] += quantity;
            }
        }
    }
}
