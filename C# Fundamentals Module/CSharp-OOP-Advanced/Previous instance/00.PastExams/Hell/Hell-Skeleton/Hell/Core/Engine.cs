using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private readonly string Exit = nameof(QuitCommand).Replace("Command", string.Empty);

    private IInputReader reader;
    private IOutputWriter writer;
    private ICommandInterpreter commandInterpreter;
    private bool isRunning;

    public Engine(IInputReader reader, IOutputWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        this.isRunning = true;

        while (this.isRunning)
        {
            var inputLine = this.reader.ReadLine();

            var inputParams = inputLine.Split();

            var commandName = inputParams[0];
            var commandArgs = inputParams.Skip(1).ToList();

            var command = this.commandInterpreter
                .GetCommand(commandName, commandArgs);

            var result = command.Execute();

            this.writer.WriteLine(result);

            this.isRunning = commandName != this.Exit;
        }
    }
}