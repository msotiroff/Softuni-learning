using System;

namespace _01.SweetDessert
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            decimal availableMoney = decimal.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());    // per unit
            decimal eggPrice = decimal.Parse(Console.ReadLine());       // per unit
            decimal berriesPrice = decimal.Parse(Console.ReadLine());   // per kilo

            decimal neededPortions = (decimal)Math.Ceiling(1.0 * numberOfGuests / 6);

            decimal neededMoney = neededPortions * (2 * bananaPrice + 4 * eggPrice + berriesPrice * (decimal)0.2);

            if (availableMoney >= neededMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {neededMoney - availableMoney:f2}lv more.");
            }
        }
    }
}
