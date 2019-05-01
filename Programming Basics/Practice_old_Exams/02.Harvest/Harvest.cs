using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Harvest
{
    class Harvest
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double grapePerSquare = double.Parse(Console.ReadLine());
            double neededWine = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());

            double wine = area * grapePerSquare * 0.4 / 2.5;

            double difference = Math.Abs(neededWine - wine);

            if (wine >= neededWine)
            {
                Console.WriteLine("Good harvest this year! Total wine: {0} liters.", Math.Floor(wine));
                Console.WriteLine("{0} liters left -> {1} liters per person.", Math.Ceiling(difference), Math.Ceiling(difference / workers));
            }
            else
            {
                Console.WriteLine("It will be a tough winter! More {0} liters wine needed.", Math.Floor(difference));
            }
        }
    }
}
