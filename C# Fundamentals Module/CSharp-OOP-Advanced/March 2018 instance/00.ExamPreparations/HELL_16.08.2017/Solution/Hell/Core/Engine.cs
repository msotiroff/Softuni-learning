using System;
using System.Linq;

public class Engine : IEngine
{
    private ICommandInterpreter commandInterpreter;
    private IInputReader reader;
    private IOutputWriter writer;
    private bool isRunning;

    public Engine(IInputReader reader, IOutputWriter writer,  ICommandInterpreter commandInterpreter)
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
            var inputParams = this.reader.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = inputParams.First();
            var commandParams = inputParams.Skip(1).ToList();

            if (commandName == Constants.EndCommand)
            {
                this.isRunning = false;
            }

            var command = this.commandInterpreter.InterpretCommand(commandName, commandParams);

            var result = command.Execute();

            if (!string.IsNullOrEmpty(result))
            {
                this.writer.WriteLine(result);
            }
        }
    }
}