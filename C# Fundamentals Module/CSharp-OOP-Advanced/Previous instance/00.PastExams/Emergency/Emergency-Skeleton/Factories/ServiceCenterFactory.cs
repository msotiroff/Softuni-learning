using Emergency_Skeleton.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Emergency_Skeleton.Factories
{
    public class ServiceCenterFactory : IServiceCenterFactory
    {
        public IServiceCenter CreateServiceCenter(string centerType, IEnumerable<string> parameters)
        {
            var args = parameters.ToArray();
            var name = args[0];
            var numberOfEmergencies = int.Parse(args[1]);

            var serviceCenterType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IServiceCenter))
                    && !t.IsAbstract)
                .FirstOrDefault(t => t.Name == centerType);

            // Throw if null...

            var serviceCencer = (IServiceCenter)Activator.CreateInstance(serviceCenterType, new object[] { name, numberOfEmergencies });

            return serviceCencer;
        }
    }
}
