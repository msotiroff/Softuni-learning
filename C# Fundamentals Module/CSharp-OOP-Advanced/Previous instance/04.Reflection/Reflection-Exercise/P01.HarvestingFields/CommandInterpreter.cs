using System;
using System.Linq;
using System.Reflection;

public class CommandInterpreter
{
    public ICommand ParseCommand(string commandName)
    {
        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
            .FirstOrDefault(t => t.Name
                .ToLower()
                .Replace("command", string.Empty).Equals(commandName.ToLower()));

        if (type == null)
        {
            throw new InvalidOperationException("Invalid command name");
        }

        var command = (ICommand)Activator.CreateInstance(type, false);

        return command;
    }
}
