using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Training_Hall_Equipment
{
    class TrainingHallEquipment
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int itemsToBuy = int.Parse(Console.ReadLine());

            double subTotal = 0;
            
            for (int i = 0; i < itemsToBuy; i++)
            {
                string itemName = Console.ReadLine();
                double itemPrice = double.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());
                subTotal += 1.0 * itemPrice * itemCount;
                if (itemCount > 1)
                {
                    Console.WriteLine($"Adding {itemCount} {itemName}s to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {itemCount} {itemName} to cart.");
                }
            }

            double difference = Math.Abs(subTotal - budget);

            Console.WriteLine($"Subtotal: ${subTotal:f2}");

            if (budget >= subTotal)
            {
                Console.WriteLine($"Money left: ${difference:f2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${difference:f2} more.");
            }
        }
    }
}
