using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        var className = nameof(BlackBoxInt);
        var blackBoxType = Type.GetType(className);

        var instance = (BlackBoxInt)Activator.CreateInstance(blackBoxType, true);

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split('_');

            var methodName = tokens.First();
            var argument = int.Parse(tokens.Last());

            blackBoxType
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(mi => mi.Name.Equals(methodName))
                ?.Invoke(instance, new object[] { argument });

            var field = blackBoxType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(instance);

            Console.WriteLine(field);
        }
    }
}
