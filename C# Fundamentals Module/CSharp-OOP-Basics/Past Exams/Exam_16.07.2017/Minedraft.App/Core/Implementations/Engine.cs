using System;
using System.Linq;

public class Engine : IEngine
{
    private readonly DraftManager draftManager;

    public Engine(DraftManager draftManager)
    {
        this.draftManager = draftManager;
    }

    public void Run()
    {
        while (true)
        {
            var inputLine = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = inputLine.First();
            var commandArgs = inputLine.Skip(1).ToList();

            var result = string.Empty;
            
                switch (commandName)
                {
                    case "RegisterHarvester":
                        result = this.draftManager.RegisterHarvester(commandArgs);
                        break;
                    case "RegisterProvider":
                        result = this.draftManager.RegisterProvider(commandArgs);
                        break;
                    case "Day":
                    result = this.draftManager.Day();
                        break;
                    case "Mode":
                        result = this.draftManager.Mode(commandArgs);
                        break;
                    case "Check":
                        result = this.draftManager.Check(commandArgs);
                        break;
                    case "Shutdown":
                        result = this.draftManager.ShutDown();
                        Console.WriteLine(result);
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(result);
        }
    }
}
