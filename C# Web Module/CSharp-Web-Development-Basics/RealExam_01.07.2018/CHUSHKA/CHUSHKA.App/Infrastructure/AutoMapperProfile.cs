namespace CHUSHKA.App.Infrastructure
{
    using AutoMapper;
    using CHUSHKA.Services.Contracts;
    using Common.AutoMapping;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.InitializeMapper();
        }
        
        private void InitializeMapper()
        {
            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().FullName.Contains(nameof(CHUSHKA)))
                .SelectMany(a => a.GetTypes())
                .Concat(Assembly.GetAssembly(typeof(IService)).GetTypes());
            
            var allMappingTypes = allTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && t.GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => i.GetGenericTypeDefinition())
                            .Contains(typeof(IMapWith<>)))
                .Select(t => new
                {
                    Destination = t,
                    Sourse = t.GetInterfaces()
                        .Where(i => i.IsGenericType)
                        .Select(i => new
                        {
                            Definition = i.GetGenericTypeDefinition(),
                            Arguments = i.GetGenericArguments()
                        })
                        .Where(i => i.Definition == typeof(IMapWith<>))
                        .SelectMany(i => i.Arguments)
                        .First()
                })
                .ToList();

            // Creates bidirectional mapping!
            foreach (var type in allMappingTypes)
            {
                this.CreateMap(type.Destination, type.Sourse);
                this.CreateMap(type.Sourse, type.Destination);
            }
        }
    }
}
