namespace Airport.App
{
    using AutoMapper;
    using Data;
    using Infrastructure;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;
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

            var context = serviceProvider.GetRequiredService<AirportDbContext>();
            MigrateDatabase(context);
            
            var server = new WebServer(8000, new DependencyControllerRouter(serviceProvider), new ResourceRouter());

            MvcEngine.Run(server);
        }

        private static void MigrateDatabase(AirportDbContext context)
        {
            context.Database.Migrate();
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

            services.AddDbContext<AirportDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
