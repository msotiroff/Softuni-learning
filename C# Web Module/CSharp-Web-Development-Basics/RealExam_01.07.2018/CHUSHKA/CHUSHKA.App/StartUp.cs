namespace CHUSHKA.App
{
    using AutoMapper;
    using Data;
    using Infrastructure;
    using Infrastructure.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using SoftUni.WebServer.Mvc;
    using SoftUni.WebServer.Mvc.Routers;
    using SoftUni.WebServer.Server;
    using System;

    public class StartUp
    {
        /// <summary>
        /// 1) Used toastr notifications
        /// 2) Used Service Layer
        /// 3) Used Dependency injection from container
        /// 4) Implemented customized ControllerRouter in the application, in order to inject all dependencies
        /// 5) Used AutoMapper
        /// </summary>
        public static void Main()
        {
            ConfigureAutoMapper();

            var serviceProvider = ConfigureServices();

            var database = serviceProvider.GetRequiredService<CHUSHKADbContext>();
            database.SeedData();

            var server = new WebServer(8000, new DependentControllerRouter(serviceProvider), new ResourceRouter());
            
            MvcEngine.Run(server);
        }
        
        private static void ConfigureAutoMapper()
        {
            Mapper
                .Initialize(config =>
                    config.AddProfile<AutoMapperProfile>());
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<CHUSHKADbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
