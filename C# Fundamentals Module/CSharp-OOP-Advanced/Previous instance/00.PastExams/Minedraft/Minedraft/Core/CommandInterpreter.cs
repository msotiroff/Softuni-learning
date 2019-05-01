using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0];
        var commandParams = args.Skip(1).ToList();

        ICommand command = this.SetCommand(commandName, commandParams);

        var result = command.Execute();

        return result;
    }

    private ICommand SetCommand(string commandName, List<string> commandParams)
    {
        var commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(ICommand))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == $"{commandName}{Constants.CommandSuffix}");

        //if (commandType == null)
        //{
        //    throw new InvalidOperationException("Invalid command type!");
        //}

        var instance = (ICommand)Activator.CreateInstance(commandType, new object[] { commandParams });

        var command = this.InjectDependencies(instance);

        return command;
    }

    private ICommand InjectDependencies(ICommand instancedCommand)
    {
        var dependencies = instancedCommand
            .GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(f => f.GetCustomAttributes()
                .Any(a => a.GetType() == typeof(InjectAttribute)))
            .ToArray();

        foreach (var dependency in dependencies)
        {
            var dependencyInstance = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.Name == dependency.Name);

            var value = dependencyInstance.GetValue(this);

            dependency.SetValue(instancedCommand, value);
        }

        return instancedCommand;
    }
}
