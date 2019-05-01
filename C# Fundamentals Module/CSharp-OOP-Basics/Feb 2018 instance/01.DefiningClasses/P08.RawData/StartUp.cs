namespace P08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var amountOfCars = int.Parse(Console.ReadLine());

            var allCars = new List<Car>();

            // Input format: 
            // <Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>

            for (int i = 0; i < amountOfCars; i++)
            {
                var carParams = Console.ReadLine().Split();

                var model = carParams[0];
                var engineSpeed = int.Parse(carParams[1]);
                var enginePower = int.Parse(carParams[2]);
                var cargoWeight = int.Parse(carParams[3]);
                var cargoType = carParams[4];
                var tyreOnePressure = double.Parse(carParams[5]);
                var tyreOneAge = int.Parse(carParams[6]);
                var tyreTweoPressure = double.Parse(carParams[7]);
                var tyreTwoAge = int.Parse(carParams[8]);
                var tyreThreePressure = double.Parse(carParams[9]);
                var tyreThreeAge = int.Parse(carParams[10]);
                var tyreFourPressure = double.Parse(carParams[11]);
                var tyreFourAge = int.Parse(carParams[12]);

                var tyres = new Tyre[]
                {
                    new Tyre(tyreOneAge, tyreOnePressure),
                    new Tyre(tyreTwoAge, tyreTweoPressure),
                    new Tyre(tyreThreeAge, tyreThreePressure),
                    new Tyre(tyreFourAge, tyreFourPressure)
                };

                var cargo = new Cargo(cargoType, cargoWeight);
                var engine = new Engine(engineSpeed, enginePower);

                var car = new Car(model, engine, cargo, tyres);

                allCars.Add(car);
            }

            string cargoTypeForPrint = Console.ReadLine();

            if (cargoTypeForPrint.Equals("fragile"))
            {
                allCars
                    .Where(c => c.Cargo.Type == "fragile"
                        && c.Tyres
                            .Any(t => t.Pressure < 1))
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
            }
            else if (cargoTypeForPrint.Equals("flamable"))
            {
                allCars
                    .Where(c => c.Cargo.Type == "flamable"
                        && c.Engine.Power > 250)
                .ToList()
                .ForEach(c => Console.WriteLine(c.Model));
            }
        }
    }
}
