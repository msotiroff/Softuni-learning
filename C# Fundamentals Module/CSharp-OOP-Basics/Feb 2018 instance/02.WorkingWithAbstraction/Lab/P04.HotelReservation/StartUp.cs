namespace P04.HotelReservation
{
    using Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var holidayArgs = Console.ReadLine().Split();

            var price = PriceCalculator.CalculatePrice(holidayArgs);

            Console.WriteLine($"{price:f2}");
        }
    }
}
