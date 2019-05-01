using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Styrofoam
{
    class Styrofoam
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double houseArea = double.Parse(Console.ReadLine());
            int windows = int.Parse(Console.ReadLine());
            double styrofoamPerPack = double.Parse(Console.ReadLine());
            double packPrice = double.Parse(Console.ReadLine());

            double netArea = (houseArea - windows * 2.4) * 1.1;
            double neededPacks = Math.Ceiling(netArea / styrofoamPerPack);
            double styrofoamCosts = neededPacks * packPrice;

            double difference = Math.Abs(budget - styrofoamCosts);

            if (budget >= styrofoamCosts)
            {
                Console.WriteLine($"Spent: {styrofoamCosts:f2}");
                Console.WriteLine($"Left: {difference:f2}");
            }
            else
            {
                Console.WriteLine($"Need more: {difference:f2}");
            }
        }
    }
}
