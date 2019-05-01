using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HousePrice
{
    class HousePrice
    {
        static void Main(string[] args)
        {
            double smallestRoomArea = double.Parse(Console.ReadLine());
            double kitchenArea = double.Parse(Console.ReadLine());
            double squareMeterPrice = double.Parse(Console.ReadLine());

            double bathRoomArea = smallestRoomArea / 2;
            double middleRoomArea = smallestRoomArea * 1.1;
            double biggestRoomArea = middleRoomArea * 1.1;

            double allArea = (smallestRoomArea + middleRoomArea + biggestRoomArea + kitchenArea + bathRoomArea) * 1.05;
            double price = allArea * squareMeterPrice;

            Console.WriteLine($"{price:f2}");
        }
    }
}

