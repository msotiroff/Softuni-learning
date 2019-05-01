namespace Judge.App.Infrastructure.Extensions
{
    using Judge.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this ServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
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
                .ForEach(a => services.AddTransient(a.Interface, a.Implementation));

            return services;
        }
    }
}
