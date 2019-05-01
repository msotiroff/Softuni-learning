namespace P01_RawData
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> allCars = new List<Car>();

            int linesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < linesCount; i++)
            {
                string[] parameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];

                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                double tire1Pressure = double.Parse(parameters[5]);
                int tire1age = int.Parse(parameters[6]);
                double tire2Pressure = double.Parse(parameters[7]);
                int tire2age = int.Parse(parameters[8]);
                double tire3Pressure = double.Parse(parameters[9]);
                int tire3age = int.Parse(parameters[10]);
                double tire4Pressure = double.Parse(parameters[11]);
                int tire4age = int.Parse(parameters[12]);

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var tyres = new Tyre[]
                {
                    new Tyre(tire1Pressure, tire1age),
                    new Tyre(tire2Pressure, tire2age),
                    new Tyre(tire3Pressure, tire3age),
                    new Tyre(tire4Pressure, tire4age)
                };

                allCars.Add(new Car(model, engine, cargo, tyres));
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragileCars = allCars
                    .Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(y => y.Pressure < 1))
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragileCars));
            }
            else
            {
                List<string> flamable = allCars
                    .Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)
                    .Select(c => c.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}
