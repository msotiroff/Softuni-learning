using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class ProtectedCommand : ICommand
{
    public string Execute()
    {
        var result = new StringBuilder();

        Type
            .GetType("HarvestingFields")
            .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(fi => fi.IsFamily)
            .ToList()
            .ForEach(fi => result.AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

        return result.ToString().TrimEnd();
    }
}
