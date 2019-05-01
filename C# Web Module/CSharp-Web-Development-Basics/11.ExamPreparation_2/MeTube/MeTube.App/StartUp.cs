namespace MeTube.App
{
    using AutoMapper;
    using Data;
    using Infrastructure;
    using Infrastructure.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System;
    using WebServer;

    public class StartUp
    {
        public static void Main()
        {
            ConfigureAutoMapper();

            var serviceProvider = ConfigureServices();
            
            var server = new WebServer(8000, new DependencyControllerRouter(serviceProvider), new ResourceRouter());
            
            MvcEngine.Run(server, new MeTubeDbContext());
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

            services.AddDbContext<MeTubeDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
