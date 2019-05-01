using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    class ToyShop
    {
        static void Main(string[] args)
        {
            double hollidayPrice = double.Parse(Console.ReadLine());

            double puzzles = double.Parse(Console.ReadLine());
            double barbies = double.Parse(Console.ReadLine());
            double bears = double.Parse(Console.ReadLine());
            double minions = double.Parse(Console.ReadLine());
            double trucks = double.Parse(Console.ReadLine());

            double price = puzzles * 2.6 + barbies * 3 + bears * 4.1 + minions * 8.2 + trucks * 2;
            double allToys = puzzles + barbies + bears + minions + trucks;

            if (allToys >= 50)
            {
                price *= 0.75;
            }

            double totalPrice = price * 0.9;

            double difference = Math.Abs(totalPrice - hollidayPrice);

            if (totalPrice >= hollidayPrice)
            {
                Console.WriteLine("Yes! {0:f2} lv left.", difference);
            }
            else
            {
                Console.WriteLine($"Not enough money! {difference:f2} lv needed.");
            }

        }
    }
}
