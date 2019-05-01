namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var iUnitType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IUnit)))
                .FirstOrDefault(t => t.Name == unitType);

            if (iUnitType == null)
            {
                throw new ArgumentException("You are trying to create an invalid type of unit");
            }

            var instance = (IUnit)Activator.CreateInstance(iUnitType);

            return instance;
        }
    }
}
