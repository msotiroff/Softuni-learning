using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main(string[] args)
    {
        var carsCount = int.Parse(Console.ReadLine());

        var allCars = new List<Car>();

        for (int i = 0; i < carsCount; i++)
        {
            var carParams = Console.ReadLine().Split();

            var model = carParams[0];
            var fuelAmount = double.Parse(carParams[1]);
            var consumptionPerKm = double.Parse(carParams[2]);

            var car = new Car(model, fuelAmount, consumptionPerKm);

            allCars.Add(car);
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            try
            {
                var commandParams = command.Split();
                var model = commandParams[1];
                var distance = double.Parse(commandParams[2]);

                var carToDrive = allCars
                    .FirstOrDefault(c => c.Model == model);

                if (carToDrive != null)
                {
                    carToDrive.Drive(distance);
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        allCars.ForEach(c => Console.WriteLine(c));
    }
}