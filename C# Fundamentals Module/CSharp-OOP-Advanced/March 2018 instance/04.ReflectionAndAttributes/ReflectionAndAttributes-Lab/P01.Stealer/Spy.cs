using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        var result = new StringBuilder()
            .AppendLine($"Class under investigation: {className}");

        var classType = Type.GetType(className);

        var classObject = Activator.CreateInstance(classType);

        var fields = classType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Where(f => fieldsToInvestigate.Contains(f.Name))
            .ToList();

        fields
            .ForEach(f => result.AppendLine($"{f.Name} = {f.GetValue(classObject)}"));

        return result.ToString().TrimEnd();
    }
}
