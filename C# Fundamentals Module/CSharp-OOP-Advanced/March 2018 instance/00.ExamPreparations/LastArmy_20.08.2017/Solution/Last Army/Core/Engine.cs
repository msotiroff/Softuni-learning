using System.Linq;

public class Engine : IEngine
{
    private const string EndCommand = "Enough! Pull back!";
    private const string AddSoldierCommand = "Soldier";
    private const string AddAmmunitionCommand = "WareHouse";
    private const string AddMissionCommand = "Mission";
    private const string RegenerateCommand = "Regenerate";

    private IGameController gameController;
    private IReader reader;
    private IWriter writer;
    private bool isRunning;

    public Engine(IGameController gameController, IReader reader, IWriter writer)
    {
        this.gameController = gameController;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        this.isRunning = true;

        string inputLine;
        while (this.isRunning = (inputLine = this.reader.ReadLine()) != EndCommand)
        {
            var inputArgs = inputLine.Split();

            var command = inputArgs.First();
            var commandParams = inputArgs.Skip(1);

            string currentResult = null;

            switch (command)
            {
                case AddSoldierCommand:
                    if (commandParams.First() == RegenerateCommand)
                    {
                        this.gameController.RegenerateSoldiers(commandParams);
                    }
                    else
                    {
                        try
                        {
                            currentResult = this.gameController.AddSoldierToArmy(commandParams);
                        }
                        catch (System.Exception ex)
                        {
                            currentResult = ex.Message;
                        }
                    }
                    break;
                case AddAmmunitionCommand:
                    this.gameController.AddAmmuniotionCountToWareHouse(commandParams);
                    break;
                case AddMissionCommand:
                    currentResult = this.gameController.AddMission(commandParams);
                    break;
                default:
                    break;
            }

            if (!string.IsNullOrEmpty(currentResult))
            {
                this.writer.AppendLine(currentResult);
            }
        }

        var results = this.gameController.RequestResults();
        this.writer.AppendLine(results);

        this.writer.WriteAllText();
    }
}
