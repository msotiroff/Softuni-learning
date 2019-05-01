using System;
using System.Collections.Generic;
using System.Linq;
class StartUp
{
    static void Main(string[] args)
    {
        int numberOfLines = int.Parse(Console.ReadLine());

        Dictionary<string, Car> allCars = new Dictionary<string, Car>();

        for (int i = 0; i < numberOfLines; i++)
        {
            string[] inputParams = Console.ReadLine().Split(' ').ToArray();
            string model = inputParams[0];
            double fuelAmount = double.Parse(inputParams[1]);
            double consumption = double.Parse(inputParams[2]);

            if (! allCars.ContainsKey(model))
            {
                Car currentCar = new Car(model, fuelAmount, consumption);
                allCars.Add(model, currentCar);
            }
        }

        string inputCommand;

        while ((inputCommand = Console.ReadLine()) != "End")
        {
            string[] inputParams = inputCommand.Split(' ').ToArray();
            string currentModel = inputParams[1];
            double amountOfKm = double.Parse(inputParams[2]);

            allCars[currentModel].Drive(amountOfKm);
        }

        foreach (var car in allCars)
        {
            Console.WriteLine($"{car.Key} {car.Value.FuelAmount:f2} {car.Value.DistanceTraveled}");
        }
    }
}