using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VehicleCatalogue
{
    public class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class VehicleCatalogue
    {
        static void Main(string[] args)
        {
            List<Vehicle> allVehicles = new List<Vehicle>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputParams = input.Split(' ');
                //  truck Man red 200

                Vehicle currentVehicle = new Vehicle()
                {
                    Type = FirstUpper(inputParams[0]),
                    Model = inputParams[1],
                    Color = inputParams[2],
                    HorsePower = int.Parse(inputParams[3])
                };

                allVehicles.Add(currentVehicle);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "Close the Catalogue")
            {
                PrintVehicleProperties(input, allVehicles);

                input = Console.ReadLine();
            }

            List<Vehicle> cars = allVehicles.Where(v => v.Type == "Car").ToList();
            List<Vehicle> trucks = allVehicles.Where(v => v.Type == "Truck").ToList();

            double carsAvgHP = 1.0 * cars.Select(c => c.HorsePower).Sum() / cars.Count;
            double trucksAvgHP = 1.0 * trucks.Select(c => c.HorsePower).Sum() / trucks.Count;
            if (trucks.Count == 0)
            {
                trucksAvgHP = 0;
            }
            if (cars.Count == 0)
            {
                carsAvgHP = 0;
            }

            Console.WriteLine($"Cars have average horsepower of: {carsAvgHP:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvgHP:f2}.");
        }

        public static string FirstUpper(string type)
        {
            var letters = type.ToCharArray();
            string result = string.Empty;

            for (int i = 0; i < letters.Length; i++)
            {
                string currLetter = letters[i].ToString();
                if (i == 0)
                {
                    result += currLetter.ToUpper();
                }
                else
                {
                    result += currLetter.ToLower();
                }
            }

            return result;
        }

        public static void PrintVehicleProperties(string input, List<Vehicle> allVehicles)
        {
            string modelToPrint = input;

            foreach (var vehicle in allVehicles)
            {
                if (vehicle.Model == modelToPrint)
                {
                    Console.WriteLine($"Type: {vehicle.Type}");
                    Console.WriteLine($"Model: {vehicle.Model}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Horsepower: {vehicle.HorsePower}");
                }
            }

        }
    }
}
