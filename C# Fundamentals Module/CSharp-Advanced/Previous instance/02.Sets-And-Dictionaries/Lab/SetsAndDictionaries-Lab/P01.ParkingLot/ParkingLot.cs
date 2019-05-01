namespace P01.ParkingLot
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingLot
    {
        public static void Main(string[] args)
        {
            var parking = new SortedSet<string>();

            var inputLine = Console.ReadLine();

            while (inputLine != "END")
            {
                var commandParams = inputLine
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                var mainCommand = commandParams[0];

                var carPlateNumber = commandParams[1];

                switch (mainCommand)
                {
                    case "IN":
                        parking.Add(carPlateNumber);
                        break;
                    case "OUT":
                        parking.Remove(carPlateNumber);
                        break;
                    default:
                        break;
                }


                inputLine = Console.ReadLine();
            }

            Console.WriteLine(parking.Any() 
                ? string.Join(Environment.NewLine, parking) 
                : "Parking Lot is Empty");
        }
    }
}
