using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] fields)
    {
        var result = new StringBuilder()
            .AppendLine($"Class under investigation: {investigatedClass}");

        var investigatedType = Type.GetType(investigatedClass);

        var classInstance = Activator.CreateInstance(investigatedType, false);

        investigatedType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance)
            .Where(fi => fields.Contains(fi.Name))
            .Select(fi => new
            {
                fieldName = fi.Name,
                fieldValue = fi.GetValue(classInstance)
            })
            .ToList()
            .ForEach(f => result.AppendLine($"{f.fieldName} = {f.fieldValue}"));
        
        return result.ToString().TrimEnd();

    }
}
