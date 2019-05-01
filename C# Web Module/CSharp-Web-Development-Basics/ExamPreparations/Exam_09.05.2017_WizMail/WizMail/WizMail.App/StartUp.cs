namespace WizMail.App
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
            SeedDatabase();

            var serviceProvider = ConfigureServices();
            
            var server = new WebServer(8000, new DependencyControllerRouter(serviceProvider), new ResourceRouter());
            
            MvcEngine.Run(server, new WizMailDbContext());
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

            services.AddDbContext<WizMailDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }

        private static void SeedDatabase()
        {
            using (var db = new WizMailDbContext())
            {
                db.SeedData();
            }
        }
    }
}
