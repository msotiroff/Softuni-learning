using System;
using System.Linq;
using System.Reflection;

public class CommandParser : ICommandParser
{
    public MethodInfo Parse(string commandName)
    {
        var methodInfo = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.GetInterfaces()
                .Contains(typeof(IClinicManager)))
            ?.GetMethods()
            .FirstOrDefault(m => m.Name == commandName);

        if (methodInfo == null)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        return methodInfo;
    }
}
