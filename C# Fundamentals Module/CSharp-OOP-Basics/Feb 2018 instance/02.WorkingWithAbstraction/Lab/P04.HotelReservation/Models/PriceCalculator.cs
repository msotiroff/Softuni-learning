namespace P04.HotelReservation.Models
{
    using Enums;
    using System;

    public static class PriceCalculator
    {
        internal static decimal CalculatePrice(string[] holidayArgs)
        {
            var pricePerDay = decimal.Parse(holidayArgs[0]);
            var numberOfDays = int.Parse(holidayArgs[1]);
            var seasonMultiplier = (int)Enum.Parse<Season>(holidayArgs[2]);
            var discount = 0m;

            if (holidayArgs.Length > 3)
            {
                discount = (decimal)((int)Enum.Parse<DiscountType>(holidayArgs[3])) / 10;
            }

            var price = (pricePerDay * numberOfDays) * seasonMultiplier * (1 - discount);

            return price;
        }
    }
}
