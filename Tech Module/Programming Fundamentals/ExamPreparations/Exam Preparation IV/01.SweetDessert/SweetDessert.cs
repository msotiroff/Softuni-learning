using System;

namespace _01.SweetDessert
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            double cash = double.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            double bananasPrice = double.Parse(Console.ReadLine());
            double eggsPrice = double.Parse(Console.ReadLine());
            double berriesPricePerKilo = double.Parse(Console.ReadLine());
            
            int setOfPortions = (int)(Math.Ceiling(1.0 * numberOfGuests / 6));

            double neededMoney = setOfPortions * (2 * bananasPrice + 4 * eggsPrice + 0.2 * berriesPricePerKilo);

            double difference = Math.Abs(cash - neededMoney);

            if (cash >= neededMoney)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {neededMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {difference:f2}lv more.");
            }
        }
    }
}
