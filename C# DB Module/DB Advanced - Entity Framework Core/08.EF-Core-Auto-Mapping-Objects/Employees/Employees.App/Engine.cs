namespace Employees.App
{
    using System;
    using System.Linq;

    internal class Engine
    {
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        internal void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();

                    string[] commandParameters = input.Split();
                    string commandName = commandParameters[0];
                    string[] commandArgs = commandParameters.Skip(1).ToArray();

                    var command = CommandParser.ParseCommand(serviceProvider, commandName);

                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}