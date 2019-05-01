namespace P02.VehiclesExtension
{
    using Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var carParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            var truckParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            var busParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Select(double.Parse)
                .ToArray();

            var car = new Car(carParams[0], carParams[1], carParams[2]);
            var truck = new Truck(truckParams[0], truckParams[1], truckParams[2]);
            var bus = new Bus(busParams[0], busParams[1], busParams[2]);

            var inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                try
                {
                    var commandArgs = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var mainCommand = commandArgs[0];
                    var vehicleType = commandArgs[1];
                    var parameter = double.Parse(commandArgs[2]);

                    switch (mainCommand)
                    {
                        case "DriveEmpty":
                            bus.DriveEmpty(parameter);
                            Console.WriteLine($"Bus travelled {parameter} km");
                            break;
                        case "Drive":
                            if (vehicleType == "Car")
                            {
                                car.Drive(parameter);
                            }
                            else if (vehicleType == "Truck")
                            {
                                truck.Drive(parameter);
                            }
                            else if (vehicleType == "Bus")
                            {
                                bus.Drive(parameter);
                            }
                            Console.WriteLine($"{vehicleType} travelled {parameter} km");
                            break;
                        case "Refuel":
                            if (vehicleType == "Car")
                            {
                                car.Refuel(parameter);
                            }
                            else if (vehicleType == "Truck")
                            {
                                truck.Refuel(parameter);
                            }
                            else if (vehicleType == "Bus")
                            {
                                bus.Refuel(parameter);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
