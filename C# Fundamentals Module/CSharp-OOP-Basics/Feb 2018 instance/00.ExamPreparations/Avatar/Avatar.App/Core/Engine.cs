using System;
using System.Linq;

public class Engine
{
    private readonly NationsBuilder nationsBuilder;
    private bool isRunning;

    public Engine(NationsBuilder nationsBuilder)
    {
        this.nationsBuilder = nationsBuilder;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var commandLine = Console.ReadLine().Split();

            var mainCommand = commandLine.First();

            var commandParams = commandLine.Skip(1).ToList();

            var result = string.Empty;

            switch (mainCommand)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(commandParams);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(commandParams);
                    break;
                case "Status":
                    result = this.nationsBuilder.GetStatus(commandParams.First());
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(commandParams.First());
                    break;
                case "Quit":
                    this.isRunning = false;
                    result = this.nationsBuilder.GetWarsRecord();
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
