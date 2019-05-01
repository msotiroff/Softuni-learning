namespace WizMail.App.Infrastructure
{
    using AutoMapper;
    using Common.AutoMapping;
    using Extensions;
    using System;
    using System.Linq;
    using System.Reflection;
    using WizMail.Services.Contracts;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.InitializeMapper();
        }

        /// <summary>
        /// Creates bidirectional mapping for all types, which extends IMapWith<TModel> interface
        /// and configure custom mapping for all types, which extends IHaveCustomMapping interface
        /// </summary>
        private void InitializeMapper()
        {
            var allTypes = AppDomain
                .CurrentDomain
                .GetAssemblies()
                .Where(a => a.GetName().FullName.Contains(nameof(WizMail)))
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

            foreach (var type in allMappingTypes)
            {
                this.CreateMap(type.Destination, type.Sourse);
                this.CreateMap(type.Sourse, type.Destination);
            }

            allTypes
                .Where(t => t.IsClass
                    && !t.IsAbstract
                    && typeof(IHaveCustomMapping).IsAssignableFrom(t))
                .Select(Activator.CreateInstance)
                .Cast<IHaveCustomMapping>()
                .ForEach(mapping => mapping.ConfigureMapping(this));
        }
    }
}
