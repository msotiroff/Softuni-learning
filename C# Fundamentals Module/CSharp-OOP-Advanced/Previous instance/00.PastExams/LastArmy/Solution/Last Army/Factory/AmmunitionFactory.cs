using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        var ammunitionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IAmmunition))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == ammunitionName);

        var ammunition = Activator.CreateInstance(ammunitionType, new object[] { ammunitionName });

        return (IAmmunition)ammunition;
    }
}
