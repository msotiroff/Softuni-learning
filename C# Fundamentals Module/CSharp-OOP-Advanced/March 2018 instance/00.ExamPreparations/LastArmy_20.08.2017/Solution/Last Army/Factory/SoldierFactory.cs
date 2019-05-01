using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        var soldierType = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(ISoldier))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == soldierTypeName);

        var soldier = Activator.CreateInstance(soldierType, new object[] { name, age, experience, endurance });

        return (ISoldier)soldier;
    }
}
