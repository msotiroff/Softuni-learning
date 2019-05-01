using System;
using System.Linq;

public class Engine
{
    private readonly char[] delimiters = "(), ".ToCharArray();

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
            try
            {
                string inputCommand = Console.ReadLine();

                var commandTokens = inputCommand
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                var commandName = commandTokens.First();

                var commandArgs = commandTokens.Skip(1).ToArray();

                var result = string.Empty;

                if (inputCommand == "System Split")
                {
                    this.isRunning = false;
                    commandName = "SystemSplit";
                }

                switch (commandName)
                {
                    case "RegisterPowerHardware":
                        this.commandInterpreter.RegisterPowerHardware(commandArgs);
                        break;
                    case "RegisterHeavyHardware":
                        this.commandInterpreter.RegisterHeavyHardware(commandArgs);
                        break;
                    case "RegisterExpressSoftware":
                        this.commandInterpreter.RegisterExpressSoftware(commandArgs);
                        break;
                    case "RegisterLightSoftware":
                        this.commandInterpreter.RegisterLightSoftware(commandArgs);
                        break;
                    case "ReleaseSoftwareComponent":
                        this.commandInterpreter.ReleaseSoftwareComponent(commandArgs);
                        break;
                    case "Analyze":
                        result = this.commandInterpreter.Analyze();
                        break;
                    case "Dump":
                        this.commandInterpreter.Dump(commandArgs);
                        break;
                    case "Restore":
                        this.commandInterpreter.Restore(commandArgs);
                        break;
                    case "Destroy":
                        this.commandInterpreter.Destroy(commandArgs);
                        break;
                    case "DumpAnalyze":
                        result = this.commandInterpreter.DumpAnalyze();
                        break;
                    case "SystemSplit":
                        result = this.commandInterpreter.SystemSplit(commandArgs);
                        break;
                    default:
                        break;
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
