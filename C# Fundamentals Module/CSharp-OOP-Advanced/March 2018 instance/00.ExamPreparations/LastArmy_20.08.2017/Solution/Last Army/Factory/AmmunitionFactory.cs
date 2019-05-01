using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        var ammunitionType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IAmmunition))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == name);
        
        var ammunition = Activator.CreateInstance(ammunitionType, new object[] { name });

        return (IAmmunition)ammunition;
    }
}
