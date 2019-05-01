using System.Reflection;

public interface ICommandParser
{
    MethodInfo Parse(string commandName);
}
