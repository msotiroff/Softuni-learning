namespace Employees.App.Commands
{
    using System;
    using Employees.App.Interfaces;

    public class Exit : ICommand
    {
        public string Execute(params string[] args)
        {
            Console.WriteLine("GoodBye");

            Environment.Exit(0);

            return string.Empty;
        }
    }
}
