namespace P02_CarsSalesman
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allCars = new List<Car>();
            var allEngines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {
                    allEngines.Add(new Engine(model, power, displacement));
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    allEngines.Add(new Engine(model, power, efficiency));
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    allEngines.Add(new Engine(model, power, int.Parse(parameters[2]), efficiency));
                }
                else
                {
                    allEngines.Add(new Engine(model, power));
                }
            }

            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string carModel = parameters[0];
                string engineModel = parameters[1];

                Engine engine = allEngines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    allCars.Add(new Car(carModel, engine, weight));
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    allCars.Add(new Car(carModel, engine, color));
                }
                else if (parameters.Length == 4)
                {
                    string color = parameters[3];
                    allCars.Add(new Car(carModel, engine, int.Parse(parameters[2]), color));
                }
                else
                {
                    allCars.Add(new Car(carModel, engine));
                }
            }

            foreach (var car in allCars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
