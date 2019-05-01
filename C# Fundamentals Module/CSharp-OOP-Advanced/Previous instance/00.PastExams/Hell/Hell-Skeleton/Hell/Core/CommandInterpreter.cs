using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private IHeroManager heroManager;

    public CommandInterpreter(IHeroManager heroManager)
    {
        this.heroManager = heroManager;
    }

    public ICommand GetCommand(string commandName, IList<string> arguments)
    {
        var commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(ICommand)))
            .FirstOrDefault(t => t.Name == $"{commandName}{CommandSuffix}");

        if (commandType == null)
        {
            throw new InvalidOperationException("Invalid command name!");
        }

        var command = this.InjectDependencies(commandType, arguments);

        return command;
    }

    private ICommand InjectDependencies(Type commandType, IList<string> arguments)
    {
        var constructorParameters = new object[] { this.heroManager, arguments };

        var constructor = commandType.GetConstructor(new Type[] { typeof(IHeroManager), typeof(IList<string>) });

        var instance = constructor.Invoke(constructorParameters);

        return (ICommand)instance;
    }
}
