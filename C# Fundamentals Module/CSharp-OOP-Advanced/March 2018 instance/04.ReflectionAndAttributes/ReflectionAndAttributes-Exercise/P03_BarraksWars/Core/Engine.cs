namespace _03BarracksFactory.Core
{
    using System;
    using System.Linq;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    var inputArgs = input.Split();

                    var commandName = inputArgs[0];
                    var data = inputArgs.Skip(1).ToArray();

                    var command = this.commandInterpreter.InterpretCommand(data, commandName);

                    string result = command.Execute();

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
