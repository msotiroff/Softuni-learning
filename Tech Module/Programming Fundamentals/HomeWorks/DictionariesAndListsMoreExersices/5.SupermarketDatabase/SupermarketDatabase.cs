using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SupermarketDatabase
{
    class SupermarketDatabase
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Dictionary<string, List<double>> marketDataBase =
                new Dictionary<string, List<double>>();

            while (inputLine != "stocked")
            {
                string[] inputParameters = inputLine.Split(' ').ToArray();
                string currentProdName = inputParameters[0];
                double currentProdPrice = double.Parse(inputParameters[1]);
                double currentProdQuantity = double.Parse(inputParameters[2]);

                if (! marketDataBase.ContainsKey(currentProdName))
                {
                    marketDataBase[currentProdName] = new List<double>();
                    marketDataBase[currentProdName].Add(0);
                    marketDataBase[currentProdName].Add(0);
                }
                marketDataBase[currentProdName][0] = currentProdPrice;
                marketDataBase[currentProdName][1] += currentProdQuantity;


                inputLine = Console.ReadLine();
            }

            foreach (var product in marketDataBase) // Print information about each product
            {
                Console.WriteLine($"{product.Key}: ${product.Value[0]:F2} * {product.Value[1]} = ${product.Value[0]*product.Value[1]:F2}");
            }

            Console.WriteLine(new string('-', 30));  // Print 30 dashes

            double grandTotal = 0;
            foreach (var product in marketDataBase)  
            {
                double currentTotal = product.Value[0] * product.Value[1];
                grandTotal += currentTotal;
            }

            Console.WriteLine($"Grand Total: ${grandTotal:f2}");  // Print the grand total

        }
    }
}
