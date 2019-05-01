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

    public string AnalyzeAcessModifiers(string analizedClass)
    {
        var result = new StringBuilder();

        var analizedClassType = Type.GetType(analizedClass);

        var classInstance = Activator.CreateInstance(analizedClassType, false);

        analizedClassType
            .GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
            .Select(fi => fi.Name)
            .ToList()
            .ForEach(fn => result.AppendLine($"{fn} must be private!"));

        analizedClassType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("get"))
            .Select(mi => mi.Name)
            .ToList()
            .ForEach(mn => result.AppendLine($"{mn} have to be public!"));

        analizedClassType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("set"))
            .Select(mi => mi.Name)
            .ToList()
            .ForEach(mn => result.AppendLine($"{mn} have to be private!"));

        return result.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        var result = new StringBuilder()
            .AppendLine($"All Private Methods of Class: {className}");

        var neededClassType = Type.GetType(className);

        var baseClassName = neededClassType.BaseType.Name;

        result.AppendLine($"Base Class: {baseClassName}");

        neededClassType
            .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .ToList()
            .ForEach(pm => result.AppendLine(pm.Name));

        return result.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        var result = new StringBuilder();

        var classType = Type.GetType(className);

        var classInstance = Activator.CreateInstance(classType, false);

        classType
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("get"))
            .Select(mi => new
            {
                MethodName = mi.Name,
                MethodReturnValue = mi.ReturnType
            })
            .ToList()
            .ForEach(m => result.AppendLine($"{m.MethodName} will return {m.MethodReturnValue}"));

        classType
            .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance)
            .Where(mi => mi.Name.StartsWith("set"))
            .Select(mi => new
            {
                MethodName = mi.Name,
                ParameterTypeName = mi.GetParameters().First().ParameterType
            })
            .ToList()
            .ForEach(m => result.AppendLine($"{m.MethodName} will set field of {m.ParameterTypeName}"));


        return result.ToString().TrimEnd();
    }
}
