using System;

public class ConsoleReader
{
    private readonly CommandInterpreter commandInterpreter;

    public ConsoleReader(CommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void StartReadingCommands()
    {
        while (true)
        {
            var commandName = Console.ReadLine();

            var command = this.commandInterpreter.ParseCommand(commandName);

            var result = command.Execute();

            Console.WriteLine(result.Replace("family", "protected"));
        }
    }
}
