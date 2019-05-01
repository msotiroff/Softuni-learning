namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
			var setType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(ISet))
                && !t.IsAbstract)
                .FirstOrDefault(s => s.Name == type);

            var set = (ISet)Activator.CreateInstance(setType, new object[] { name });

            return set;
        }
	}
}
