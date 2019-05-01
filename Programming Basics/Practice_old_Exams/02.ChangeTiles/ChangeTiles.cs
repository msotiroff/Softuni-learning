using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChangeTiles
{
    class ChangeTiles
    {
        static void Main(string[] args)
        {
            double savedMoney = double.Parse(Console.ReadLine());
            double floorWidth = double.Parse(Console.ReadLine());
            double floorLenght = double.Parse(Console.ReadLine());
            double tileSideA = double.Parse(Console.ReadLine());
            double tileSideH = double.Parse(Console.ReadLine());
            double tilePrice = double.Parse(Console.ReadLine());
            double masterPayment = double.Parse(Console.ReadLine());

            double floorArea = floorLenght * floorWidth;
            double tileArea = tileSideA * tileSideH / 2;
            double neededTiles = Math.Ceiling(floorArea / tileArea) + 5;
            double moneyNeeded = neededTiles * tilePrice + masterPayment;

            double difference = Math.Abs(moneyNeeded - savedMoney);

            if (savedMoney >= moneyNeeded)
            {
                Console.WriteLine("{0:f2} lv left.", difference);
            }
            else
            {
                Console.WriteLine("You'll need {0:f2} lv more.", difference);
            }
        }
    }
}
