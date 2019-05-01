using System;
using System.Linq;

public class Engine
{
    private readonly CommandInterpreter commandInterpreter;
    private bool isRunning;

    public Engine(CommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
        this.isRunning = false;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var inputLine = Console.ReadLine();

            if (inputLine == "Paw Paw Pawah")
            {
                isRunning = false;
                continue;
            }

            var inputSplitted = inputLine
                .Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = inputSplitted.First();
            var commandParams = inputSplitted.Skip(1).ToArray();

            switch (commandName)
            {
                case "RegisterCleansingCenter":
                    this.commandInterpreter.RegisterCleansingCenter(commandParams);
                    break;
                case "RegisterAdoptionCenter":
                    this.commandInterpreter.RegisterAdoptionCenter(commandParams);
                    break;
                case "RegisterDog":
                    this.commandInterpreter.RegisterDog(commandParams);
                    break;
                case "RegisterCat":
                    this.commandInterpreter.RegisterCat(commandParams);
                    break;
                case "SendForCleansing":
                    this.commandInterpreter.SendForCleansing(commandParams);
                    break;
                case "Cleanse":
                    this.commandInterpreter.Cleanse(commandParams);
                    break;
                case "Adopt":
                    this.commandInterpreter.Adopt(commandParams);
                    break;
                default:
                    break;
            }
        }

        var result = this.commandInterpreter.GetStatistics();

        Console.WriteLine(result);
    }
}
