namespace Forum.App.Factories
{
	using Contracts;
    using Forum.App.Common;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private const string NotACommandErrorMsg = "{0} is not a command!";
        private const string CommandNotFoundErrorMsg = "Command not found!";

        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

		public ICommand CreateCommand(string commandName)
		{
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => !t.IsAbstract)
                .FirstOrDefault(t => t.Name == $"{commandName}{Constants.CommandSuffix}")
                ?? throw new InvalidOperationException(CommandNotFoundErrorMsg);

            var isCommand = typeof(ICommand).IsAssignableFrom(commandType);

            if (!isCommand)
            {
                throw new InvalidOperationException(string.Format(NotACommandErrorMsg, commandName));
            }

            var parameters = commandType
                .GetConstructors()
                .First()
                .GetParameters()
                .Select(p => this.serviceProvider.GetService(p.ParameterType))
                .ToArray();

            var command = (ICommand)Activator.CreateInstance(commandType, parameters);

            return command;
		}
	}
}
