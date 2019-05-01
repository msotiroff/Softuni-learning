using System.Linq;

public class Engine : IEngine
{
    private const string EndCommand = "Enough! Pull back!";

    private bool isRunning;
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.isRunning = false;
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        this.isRunning = true;

        string inputLine;
        while (this.isRunning = (inputLine = this.reader.ReadLine()) != EndCommand)
        {
            var output = string.Empty;

            var inputArgs = inputLine.Split();

            var command = inputArgs.First();
            var commandParams = inputArgs.Skip(1).ToArray();
            output = ExecuteCommand(output, command, commandParams);

            if (!string.IsNullOrEmpty(output))
            {
                this.writer.WriteLine(output);
            }
        }

        var finalResults = this.gameController.RequestResults();

        this.writer.WriteLine(finalResults);
    }

    private string ExecuteCommand(string output, string command, string[] commandParams)
    {
        switch (command)
        {
            case "Soldier":
                var soldierType = commandParams[0];

                if (commandParams.First().Equals("Regenerate"))
                {
                    output = this.gameController.RegenerateSoldiers(soldierType);
                }
                else
                {
                    // [Type] [Name] [Age] [Experience] [Endurance]
                    var soldierName = commandParams[1];
                    var age = int.Parse(commandParams[2]);
                    var experience = double.Parse(commandParams[3]);
                    var endurance = double.Parse(commandParams[4]);

                    output = this.gameController.AddSoldierToArmy(soldierType, soldierName, age, experience, endurance);
                }
                break;
            case "WareHouse":
                // [Name] [Count]
                var name = commandParams[0];
                var count = int.Parse(commandParams[1]);

                output = this.gameController.AddAmmunitionsToWarehouse(name, count);
                break;
            case "Mission":
                // [Type] [Score to Complete]
                var type = commandParams[0];
                var scoreToComplete = double.Parse(commandParams[1]);

                output = this.gameController.AddMission(type, scoreToComplete);
                break;
            default:
                break;
        }

        return output;
    }
}
