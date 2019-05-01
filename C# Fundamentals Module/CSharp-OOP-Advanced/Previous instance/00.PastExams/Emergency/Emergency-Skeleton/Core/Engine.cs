using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Utils;
using System.Linq;

namespace Emergency_Skeleton.Core
{
    public class Engine : IEngine
    {
        private bool isRunning;
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            string input = string.Empty;
            while (this.isRunning = (input = this.reader.ReadLine()) != Constants.EndCommand)
            {
                var inputArgs = input.Split('|');

                var commandName = inputArgs.First();
                var commandArguments = inputArgs.Skip(1);

                ICommand command = this.commandInterpreter.InterpretCommand(commandName, commandArguments);
                var result = command.Execute();

                this.writer.AppendLine(result);
            }

            this.writer.WriteAllText();
        }
    }
}
