using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class ProviderFactory : IProviderFactory
{
    public IProvider GenerateProvider(IList<string> args)
    {
        // Hammer {id} {energyOutput}
        var providerSuffix = "Provider";

        var providerType = args[0];
        var id = int.Parse(args[1]);
        var energyOutput = double.Parse(args[2]);

        var instanceType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IProvider)))
            .FirstOrDefault(t => t.Name.Replace(providerSuffix, string.Empty) == providerType);

        IProvider provider = (IProvider)Activator.CreateInstance(instanceType, new object[] { id, energyOutput });

        return provider;
    }
}
