using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOff = int.Parse(Console.ReadLine());
            int leftFood = int.Parse(Console.ReadLine());
            double dogNeed = double.Parse(Console.ReadLine());
            double catNeed = double.Parse(Console.ReadLine());
            double turtleNeed = double.Parse(Console.ReadLine()) / 1000;

            double allFoodNeeded = (dogNeed + catNeed + turtleNeed) * daysOff;
            double difference = Math.Abs(allFoodNeeded - leftFood);

            if (leftFood >= allFoodNeeded)
            {
                Console.WriteLine("{0} kilos of food left.", Math.Floor(difference));
            }
            else
            {
                Console.WriteLine("{0} more kilos of food are needed.", Math.Ceiling(difference));
            }

        }
    }
}
