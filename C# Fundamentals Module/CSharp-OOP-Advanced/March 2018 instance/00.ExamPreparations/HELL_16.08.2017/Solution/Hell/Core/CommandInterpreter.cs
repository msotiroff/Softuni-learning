using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IServiceProvider serviceProvider;
    private IList<string> tempCommandArguments;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public ICommand InterpretCommand(string commandName, IList<string> arguments)
    {
        this.tempCommandArguments = arguments;

        var commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(ICommand))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == $"{commandName}{Constants.CommandSuffix}");

        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command!");
        }

        var command = this.InjectDependencies(commandType);

        return command;
    }

    private ICommand InjectDependencies(Type commandType)
    {
        var ctorParameters = commandType
            .GetConstructors()
            .First()
            .GetParameters()
            .ToArray()
            .Select(pi => pi.ParameterType);

        var dependencies = new List<object>();

        foreach (var parameterType in ctorParameters)
        {

            if (parameterType == typeof(IList<string>))
            {
                dependencies.Add(this.tempCommandArguments);
            }
            else
            {
                dependencies.Add(this.serviceProvider.GetService(parameterType));
            }
        }

        var command = (ICommand)Activator.CreateInstance(commandType, dependencies.ToArray());

        return command;
    }
}
