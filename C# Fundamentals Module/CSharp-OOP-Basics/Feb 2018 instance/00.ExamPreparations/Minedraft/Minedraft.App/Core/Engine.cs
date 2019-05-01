using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private bool isRunning;

    public Engine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
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
                case "RegisterHarvester":
                    result = this.draftManager.RegisterHarvester(commandParams);
                break;
                case "RegisterProvider":
                    result = this.draftManager.RegisterProvider(commandParams);
                    break;
                case "Day":
                    result = this.draftManager.Day();
                    break;
                case "Mode":
                    result = this.draftManager.Mode(commandParams);
                    break;
                case "Check":
                    result = this.draftManager.Check(commandParams);
                    break;
                case "Shutdown":
                    result = this.draftManager.ShutDown();
                    this.isRunning = false;
                    break;
                default:
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
