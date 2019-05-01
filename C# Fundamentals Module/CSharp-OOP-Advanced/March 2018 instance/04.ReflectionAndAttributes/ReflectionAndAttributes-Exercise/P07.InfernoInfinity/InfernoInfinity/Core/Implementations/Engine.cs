namespace InfernoInfinity.Core.Implementations
{
    using InfernoInfinity.Core.Contracts;
    using InfernoInfinity.IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    var inputArgs = this.reader.ReadLine().Split(';');

                    var commandName = inputArgs.First();
                    var commandParams = inputArgs.Skip(1).ToArray();

                    var command = this.commandInterpreter.InterpretCommand(commandName, commandParams);

                    var result = command.Execute();

                    if (result != string.Empty)
                    {
                        this.writer.WriteLine(result);
                    }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
