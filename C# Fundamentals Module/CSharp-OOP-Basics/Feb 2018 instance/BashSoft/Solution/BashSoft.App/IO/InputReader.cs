namespace BashSoft.App.IO
{
    using Core;
    using System;
    using System.Linq;

    public class InputReader
    {
        private readonly CommandInterpreter commandInterpreter;

        public InputReader(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void StartReadingCommands()
        {
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.currentPath}> ");
                var input = Console.ReadLine();

                var commandArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var commandName = commandArgs.First();
                    var commandParams = commandArgs.Skip(1).ToArray();

                    // Returns new instance of interface IInterpretable, that nestles all commands
                    var command = this.commandInterpreter.InterpretCommand(commandName);

                    var result = command.Interpret(commandParams);

                    OutputWriter.WriteMessageOnNewLine(result);
                }
                catch (Exception ex)
                {
                    OutputWriter.DisplayException(ex.Message);
                }
            }
        }
    }
}
