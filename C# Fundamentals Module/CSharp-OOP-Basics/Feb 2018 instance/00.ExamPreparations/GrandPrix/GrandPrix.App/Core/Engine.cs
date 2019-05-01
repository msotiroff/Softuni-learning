using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;
    private bool isRunning;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        this.raceTower.SetTrackInfo(numberOfLaps, trackLength);

        while (this.isRunning)
        {
            var commandLine = Console.ReadLine().Split();

            var mainCommand = commandLine.First();
            var commandParams = commandLine.Skip(1).ToList();

            var result = string.Empty;

            switch (mainCommand)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(commandParams);
                    break;
                case "Leaderboard":
                    result = this.raceTower.GetLeaderboard();
                    break;
                case "CompleteLaps":
                    result = this.raceTower.CompleteLaps(commandParams);
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(commandParams);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(commandParams);
                    break;
                default:
                    break;
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }

            if (this.raceTower.LapsLeft == 0)
            {
                var winnerInfo = this.raceTower.GetWinnerInfo();
                Console.WriteLine(winnerInfo);
                this.isRunning = false;
            }
        }
    }
}
