using System;
using System.Linq;
using System.Text;
using System.Reflection;

public class PublicCommand : ICommand
{
    public string Execute()
    {
        var result = new StringBuilder();

        Type
            .GetType("HarvestingFields")
            .GetFields()
            .ToList()
            .ForEach(fi => result.AppendLine($"{fi.Attributes.ToString().ToLower()} {fi.FieldType.Name} {fi.Name}"));

        return result.ToString().TrimEnd();
    }
}
