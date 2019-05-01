namespace ModPanel.App
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
            var database = serviceProvider.GetRequiredService<ModPanelDbContext>();
            database.SeedData();

            var server = new WebServer(8000, new DependentControllerRouter(serviceProvider), new ResourceRouter());
            
            MvcEngine.Run(server, new ModPanelDbContext());
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

            services.AddDbContext<ModPanelDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
