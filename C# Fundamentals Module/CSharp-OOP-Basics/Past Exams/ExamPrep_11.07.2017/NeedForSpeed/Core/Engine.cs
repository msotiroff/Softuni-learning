using System;
using System.Linq;

public class Engine
{
    private CarManager carManager;
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
                isRunning = false;
                continue;
            }

            var inputCommandArgs = inputLine.Split();

            var mainCommand = inputCommandArgs.First();

            var commandArgs = inputCommandArgs.Skip(1).ToArray();

            var result = string.Empty;

            switch (mainCommand)
            {
                case "register":

                    int id = int.Parse(commandArgs[0]);
                    string type = commandArgs[1];
                    string brand = commandArgs[2];
                    string model = commandArgs[3];
                    int yearOfProduction = int.Parse(commandArgs[4]);
                    int horsepower = int.Parse(commandArgs[5]);
                    int acceleration = int.Parse(commandArgs[6]);
                    int suspension = int.Parse(commandArgs[7]);
                    int durability = int.Parse(commandArgs[8]);

                    this.carManager.Register(id, type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);

                    break;
                case "check":

                    result = this.carManager.Check(int.Parse(commandArgs[0]));

                    break;
                case "open":

                    int raceId = int.Parse(commandArgs[0]);
                    string racetype = commandArgs[1];
                    int length = int.Parse(commandArgs[2]);
                    string route = commandArgs[3];
                    int prizePool = int.Parse(commandArgs[4]);
                    int specialParam = 0;

                    if (commandArgs.Length > 5)
                    {
                        specialParam = int.Parse(commandArgs[5]);
                        this.carManager.Open(raceId, racetype, length, route, prizePool, specialParam);
                    }
                    else
                    {
                        this.carManager.Open(raceId, racetype, length, route, prizePool);
                    }

                    break;
                case "participate":

                    this.carManager.Participate(int.Parse(commandArgs[0]), int.Parse(commandArgs[1]));

                    break;
                case "start":

                    result = this.carManager.Start(int.Parse(commandArgs[0]));

                    break;
                case "park":

                    this.carManager.Park(int.Parse(commandArgs[0]));

                    break;
                case "unpark":

                    this.carManager.Unpark(int.Parse(commandArgs[0]));

                    break;
                case "tune":

                    int tuneIndex = int.Parse(commandArgs[0]);
                    string addOn = commandArgs[1];
                    this.carManager.Tune(tuneIndex, addOn);

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
