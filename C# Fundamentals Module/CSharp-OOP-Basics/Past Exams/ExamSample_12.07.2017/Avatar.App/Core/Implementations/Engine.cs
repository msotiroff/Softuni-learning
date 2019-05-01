using System;
using System.Linq;

public class Engine : IEngine
{
    private readonly INationsBuilder nationsBuilder;

    public Engine(INationsBuilder nationsBuilder)
    {
        this.nationsBuilder = nationsBuilder;
    }

    public void Run()
    {
        while (true)
        {
            var commandParams = Console.ReadLine()
            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var mainCommand = commandParams.First();
            var commandArgs = commandParams.Skip(1).ToList();

            var result = string.Empty;

            switch (mainCommand)
            {
                case "Bender":
                    this.nationsBuilder.AssignBender(commandArgs);
                    break;
                case "Monument":
                    this.nationsBuilder.AssignMonument(commandArgs);
                    break;
                case "Status":
                    result = this.nationsBuilder.GetStatus(commandArgs.First());
                    Console.WriteLine(result);
                    break;
                case "War":
                    this.nationsBuilder.IssueWar(commandArgs.First());
                    break;
                case "Quit":
                    result = this.nationsBuilder.GetWarsRecord();
                    Console.WriteLine(result);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}