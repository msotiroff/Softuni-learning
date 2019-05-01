using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Startup
{
    public static void Main(string[] args)
    {
        List<Car> carPark = new List<Car>();

        int numberOfLines = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfLines; i++)
        {
            //Input format: "<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> 
            //<Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>"
            string[] carParameters = Console.ReadLine().Split();

            string model = carParameters[0];

            int engineSpeed = int.Parse(carParameters[1]);
            int enginePower = int.Parse(carParameters[2]);

            int cargoWeight = int.Parse(carParameters[3]);
            string cargoType = carParameters[4];

            double firstTyrePressure = double.Parse(carParameters[5]);
            int firstTyreAge = int.Parse(carParameters[6]);

            double secondTyrePressure = double.Parse(carParameters[7]);
            int secondTyreAge = int.Parse(carParameters[8]);

            double thirdTyrePressure = double.Parse(carParameters[9]);
            int thirdTyreAge = int.Parse(carParameters[10]);

            double forthTyrePressure = double.Parse(carParameters[11]);
            int forthTyreAge = int.Parse(carParameters[12]);

            Tyre[] tyres = new Tyre[4]
            {
                new Tyre(firstTyrePressure, firstTyreAge),
                new Tyre(secondTyrePressure, secondTyreAge),
                new Tyre(thirdTyrePressure, thirdTyreAge),
                new Tyre(forthTyrePressure, forthTyreAge)
            };

            Cargo cargo = new Cargo(cargoWeight, cargoType);

            Engine engine = new Engine(engineSpeed, enginePower);

            Car currentCar = new Car(model, engine, cargo, tyres);

            carPark.Add(currentCar);
        }

        string command = Console.ReadLine();

        var selectedCars = new List<Car>();

        if (command == "fragile")
        {
            selectedCars = carPark
                .Where(c => c.Cargo.Type == "fragile")
                .Where(c => c.Tyres.Any(t => t.Pressure < 1))
                .ToList();
        }
        else if (command == "flammable")
        {
            selectedCars = carPark
                .Where(c => c.Cargo.Type == "flammable")
                .Where(c => c.Engine.Power > 250)
                .ToList();
        }

        selectedCars
            .ForEach(sc => Console.Write(sc));
    }
}
