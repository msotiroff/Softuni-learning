using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methodsByName = type
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public)
            .Where(mi => mi.CustomAttributes
                .Any(ca => ca.AttributeType == typeof(SoftUniAttribute)));

        foreach (var methodInfo in methodsByName)
        {
            var attribute = (SoftUniAttribute)methodInfo
                .GetCustomAttribute(typeof(SoftUniAttribute));

            Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
        }
    }
}
