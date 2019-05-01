namespace Employees.App
{
    using System;
    using System.Reflection;
    using System.Linq;
    using Employees.App.Interfaces;

    internal class CommandParser
    {
        public static ICommand ParseCommand(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));

            var commandType = commandTypes.SingleOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid Command.");
            }

            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParameters = constructor
                .GetParameters()
                .Select(pi => pi.ParameterType)
                .Select(p => serviceProvider.GetService(p))
                .ToArray();

            var command = (ICommand)constructor.Invoke(constructorParameters);

            return command;
        }
    }
}
