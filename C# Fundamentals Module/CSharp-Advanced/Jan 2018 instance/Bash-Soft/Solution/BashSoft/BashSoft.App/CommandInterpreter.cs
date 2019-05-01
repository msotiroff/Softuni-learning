namespace BashSoft.App
{
    using Commands.Contracts;
    using Core;
    using Extensions.CustomAttributes;
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
                .Where(t => t.GetCustomAttribute<AliasAttribute>().Types.Contains(commandName))
                .SingleOrDefault();
            
            if (commandType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
            }

            var command = (IInterpretable)Activator.CreateInstance(commandType, false);

            return command;
        }
    }
}
