using System;
using System.Linq;

public class Engine : IEngine
{
    private readonly IRaceTower raceTower;

    public Engine(IRaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        var numberOfLabs = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(numberOfLabs, trackLength);


        while (this.raceTower.CurrentLap < numberOfLabs)
        {
            var inputParams = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var command = inputParams.First();
            var commandArgs = inputParams.Skip(1).ToList();

            var result = string.Empty;

            switch (command)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandArgs);
                    break;
                case "Leaderboard":
                    result = this.raceTower.GetLeaderboard();
                    break;
                case "CompleteLaps":
                    result = this.raceTower.CompleteLaps(commandArgs);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandArgs);
                    break;
                default:
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
        }

        Console.WriteLine($"{this.raceTower.Winner.Name} wins the race for {this.raceTower.Winner.TotalTime:f3} seconds.");
    }
}