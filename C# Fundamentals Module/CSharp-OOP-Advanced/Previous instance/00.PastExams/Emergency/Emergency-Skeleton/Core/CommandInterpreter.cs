using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Emergency_Skeleton.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand InterpretCommand(string commandName, IEnumerable<string> arguments)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(ICommand))
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == commandName + Constants.CommandSuffix);

            // throw if null...

            ICommand instance = (ICommand)Activator.CreateInstance(commandType, new object[] { arguments });

            var command = this.InjectDependencies(instance);

            return command;
        }

        private ICommand InjectDependencies(ICommand instance)
        {
            var fields = instance
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                field.SetValue(instance, this.serviceProvider.GetService(field.FieldType));
            }

            return instance;
        }
    }
}
