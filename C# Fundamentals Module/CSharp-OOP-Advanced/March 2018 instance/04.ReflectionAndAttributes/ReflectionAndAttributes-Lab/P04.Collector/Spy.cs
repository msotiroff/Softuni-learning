using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string CollectGettersAndSetters(string className)
    {
        var classType = Type.GetType(className);

        var builder = new StringBuilder();

        // Getters:
        classType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("get"))
            .Select(mi => new
            {
                Name = mi.Name,
                ReturnType = mi.ReturnType.FullName
            })
            .ToList()
            .ForEach(g => builder
                .AppendLine($"{g.Name} will return {g.ReturnType}")); ;

        // Setters:
        classType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("set"))
            .Select(mi => new
            {
                Name = mi.Name,
                ReturnType = mi.ReturnType.FullName
            })
            .ToList()
            .ForEach(s => builder
                .AppendLine($"{s.Name} will set field of {s.ReturnType}"));
        
        var result = builder.ToString().TrimEnd();

        return result;
    }

    public string RevealPrivateMethods(string className)
    {
        var classType = Type.GetType(className);

        var builder = new StringBuilder()
            .AppendLine($"All Private Methods of Class: {className}")
            .AppendLine($"Base Class: {classType.BaseType.Name}");

        classType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .ToList()
            .ForEach(m => builder.AppendLine(m.Name));

        var result = builder.ToString().TrimEnd();

        return result;
    }
    
    public string AnalyzeAcessModifiers(string className)
    {
        var builder = new StringBuilder();

        var classToAnalize = Type.GetType(className);

        classToAnalize
            .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .ToList()
            .ForEach(f => builder.AppendLine($"{f.Name} must be private!"));

        classToAnalize
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static)
            .Where(m => m.Name.ToLower().StartsWith("get"))
            .ToList()
            .ForEach(m => builder.AppendLine($"{m.Name} have to be public!"));

        classToAnalize
            .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Where(m => m.Name.ToLower().StartsWith("set"))
            .ToList()
            .ForEach(m => builder.AppendLine($"{m.Name} have to be private!"));

        var result = builder.ToString().TrimEnd();

        return result;
    }

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
