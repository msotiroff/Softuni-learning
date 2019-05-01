using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        var typeName = args[0];
        var id = int.Parse(args[1]);
        var energyOutput = double.Parse(args[2]);

        var providerType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IProvider))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == $"{typeName}Provider");

        var provider = (IProvider)Activator.CreateInstance(providerType, new object[] { id, energyOutput });

        return provider;
    }
}