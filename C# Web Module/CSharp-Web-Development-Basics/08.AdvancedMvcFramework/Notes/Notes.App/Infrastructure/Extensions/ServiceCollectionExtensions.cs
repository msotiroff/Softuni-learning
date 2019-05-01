namespace Notes.App.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Repositories.Contracts.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ServiceCollectionExtensions
    {
        public static ServiceCollection AddDomainServices(this ServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IRepository<>))
                .GetTypes()
                .Where(t => t.IsClass
                    && !t.IsGenericType
                    && t.GetInterfaces()
                        .Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Interface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services
                    .AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}
