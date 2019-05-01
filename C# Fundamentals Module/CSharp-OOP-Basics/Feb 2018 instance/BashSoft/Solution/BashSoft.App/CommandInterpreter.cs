namespace BashSoft.App
{
    using Commands.Contracts;
    using Extensions.CustomAttributes;
    using Extensions.CustomExceptions;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter
    {
        public IInterpretable InterpretCommand (string commandName)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IInterpretable)))
                .Where(t => t.GetCustomAttributes<AliasAttribute>()
                    .Any())
                .Where(t => t.GetCustomAttribute<AliasAttribute>()
                    .Types
                    .Contains(commandName))
                .SingleOrDefault();
            
            if (commandType == null)
            {
                throw new InvalidCommandException(commandName);
            }

            var command = this.InjectDependencies(commandType);

            return command;
        }

        private IInterpretable InjectDependencies(Type type)
        {
            var constructor = type
                .GetConstructors()
                .First();

            var dependencies = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .Select(cp => Activator.CreateInstance(cp))
                .ToArray();

            var command = (IInterpretable)constructor.Invoke(dependencies);

            return command;
        }
    }
}
