using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;
    private IList<string> tempCommandArguments;

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
        this.tempCommandArguments = new List<string>();
    }

    public IHarvesterController HarvesterController => this.harvesterController;

    public IProviderController ProviderController => this.providerController;

    public string ProcessCommand(IList<string> args)
    {
        var commandName = args[0];
        //var commandArgs = args.Skip(1).ToList();
        this.tempCommandArguments = args.Skip(1).ToList();
        var commandType = this.FindCommand(commandName);

        //var instance = (ICommand)Activator.CreateInstance(commandType, new object[] { commandArgs });

        //var command = this.InjectDependencies(instance);

        var command = this.InjectDependencies(commandType);

        var result = command.Execute();

        return result;
    }

    private ICommand InjectDependencies(Type commandType)
    {
        var neededDependencies = commandType
            .GetConstructors()
            .First()
            .GetParameters()
            .Select(pi => pi.ParameterType)
            .ToArray();

        var ctorParams = new List<object>();

        foreach (var dependency in neededDependencies)
        {
            var dependencyToBeInjected = this
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.FieldType.Name == dependency.Name)
                ?.GetValue(this);

            if (dependencyToBeInjected != null)
            {
                ctorParams.Add(dependencyToBeInjected);
            }
        }

        ICommand command = (ICommand)Activator.CreateInstance(commandType, ctorParams.ToArray());

        return command;
    }

    //private ICommand InjectDependencies111(ICommand instance)
    //{
    //    var neededDependencies = instance
    //            .GetType()
    //            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
    //            .ToArray();

    //    foreach (var dependency in neededDependencies)
    //    {
    //        var dependencyToInject = this
    //            .GetType()
    //            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
    //            .FirstOrDefault(fi => fi.Name == dependency.Name)?
    //            .GetValue(this);

    //        dependency.SetValue(instance, dependencyToInject);
    //    }

    //    return instance;
    //}

    private Type FindCommand(string commandName)
    {
        var commandType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(ICommand))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == $"{commandName}{Constants.CommandSuffix}");

        // TODO: Throw if null

        return commandType;
    }
}
