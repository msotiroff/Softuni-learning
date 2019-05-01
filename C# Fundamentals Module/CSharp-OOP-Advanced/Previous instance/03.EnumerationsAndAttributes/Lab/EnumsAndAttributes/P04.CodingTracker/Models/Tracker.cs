using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var methods = typeof(StartUp)
            .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var methodInfo in methods)
        {
            if (methodInfo.CustomAttributes
                .Any(ca => ca.AttributeType == typeof(SoftUniAttribute)))
            {
                var attributes = methodInfo.GetCustomAttributes(false);

                foreach (SoftUniAttribute attr in attributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attr.Name}");
                }
            }
        }
    }
}
