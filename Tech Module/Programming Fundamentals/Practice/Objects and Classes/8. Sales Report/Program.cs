using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Sales_Report
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            Dictionary<string, double> salesByTown = new Dictionary<string, double>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                ReadSales(salesByTown);
            }

            foreach (var town in salesByTown.OrderBy(t => t.Key))
            {
                Console.WriteLine($"{town.Key} -> {town.Value:f2}");
            }
        }

        public static void ReadSales(Dictionary<string, double> salesByTown)
        {
            string[] currentInput = Console.ReadLine()
                                .Split(' ')
                                .ToArray();
            string currentTown = currentInput[0];
            string currentProduct = currentInput[1];
            double currentPrice = double.Parse(currentInput[2]);
            double currentQuantity = double.Parse(currentInput[3]);

            if (!salesByTown.ContainsKey(currentTown))
            {
                salesByTown[currentTown] = 0.0;
            }
            Sale currentSale = new Sale
            {
                Product = currentProduct,
                Price = currentPrice,
                Quantity = currentQuantity
            };
            salesByTown[currentTown] += GetIncomeMoney(currentSale.Price, currentSale.Quantity);
        }

        public static double GetIncomeMoney(double price, double quantity)
        {
            double incomeMoney = price * quantity;
            return incomeMoney;
        }
    }
}
