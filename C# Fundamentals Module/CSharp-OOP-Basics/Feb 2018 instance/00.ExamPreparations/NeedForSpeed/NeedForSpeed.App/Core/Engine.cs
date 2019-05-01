using System;
using System.Linq;

public class Engine
{
    private readonly CarManager carManager;
    private bool isRunning;

    public Engine(CarManager carManager)
    {
        this.carManager = carManager;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var inputLine = Console.ReadLine();

            if (inputLine == "Cops Are Here")
            {
                this.isRunning = false;
                continue;
            }

            var commandTokens = inputLine.Split();
            var mainCommand = commandTokens.First();
            var commandParams = commandTokens.Skip(1).ToArray();
            var id = int.Parse(commandParams[0]);

            var result = string.Empty;

            switch (mainCommand)
            {
                case "register":
                    string carType = commandParams[1];
                    string brand = commandParams[2];
                    string model = commandParams[3];
                    int yearOfProduction = int.Parse(commandParams[4]);
                    int horsepower = int.Parse(commandParams[5]);
                    int acceleration = int.Parse(commandParams[6]);
                    int suspension = int.Parse(commandParams[7]);
                    int durability = int.Parse(commandParams[8]);
                    this.carManager.Register(id, carType, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                    break;
                case "check":
                    result = this.carManager.Check(id);
                    break;
                case "open":
                    string raceType = commandParams[1];
                    int length = int.Parse(commandParams[2]);
                    string route = commandParams[3];
                    int prizePool = int.Parse(commandParams[4]);
                    if (commandParams.Length > 5)
                    {
                        int additionalParameter = int.Parse(commandParams[5]);
                        this.carManager.Open(id, raceType, length, route, prizePool, additionalParameter);
                    }
                    else
                    {
                        this.carManager.Open(id, raceType, length, route, prizePool);
                    }

                    break;
                case "participate":
                    var raceId = int.Parse(commandParams[1]);
                    this.carManager.Participate(id, raceId);
                    break;
                case "start":
                    result = this.carManager.Start(id);
                    break;
                case "park":
                    this.carManager.Park(id);
                    break;
                case "unpark":
                    this.carManager.Unpark(id);
                    break;
                case "tune":
                    var addOn = commandParams[1];
                    this.carManager.Tune(id, addOn);
                    break;
                default:
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }
    }
}
