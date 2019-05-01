namespace BashSoft.App
{
    using Commands.Contracts;
    using Contracts;
    using Extensions;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        public IExecutable InterpretCommand (string commandName, string[] commandParams)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IExecutable)))
                .Where(t => t.GetCustomAttributes<AliasAttribute>()
                    .Any())
                .Where(t => t.GetCustomAttribute<AliasAttribute>()
                    .Types
                    .Contains(commandName))
                .SingleOrDefault()
                ?? throw new InvalidCommandException(commandName);

            var command = (IExecutable)Activator
                .CreateInstance(commandType, new object[] { commandParams });

            var instance = this.InjectDependencies(command);

            return command;
        }

        private IExecutable InjectDependencies(IExecutable command)
        {
            command
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .ForEach(f => f.SetValue(command, this.serviceProvider.GetService(f.FieldType)));
            
            return command;
        }
    }
}
