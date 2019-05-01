namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            var instrumentType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IInstrument))
                && !t.IsAbstract)
                .FirstOrDefault(s => s.Name == type);

            var instrument = (IInstrument)Activator.CreateInstance(instrumentType, new object[] { });

            return instrument;
        }
	}
}