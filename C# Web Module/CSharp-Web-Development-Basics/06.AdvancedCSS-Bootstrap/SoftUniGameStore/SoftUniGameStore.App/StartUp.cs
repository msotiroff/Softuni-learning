namespace SoftUniGameStore.App
{
    using Data;
    using HTTPServer;
    using HTTPServer.Routing;
    using Infrastructure.Extensions;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var serviceProvider = ConfigureServices();

            var application = new GameStoreApp(serviceProvider);
            var applicationDirectory = @"../SoftUniGameStore.App";

            var appRouteConfig = new AppRouteConfig(applicationDirectory);

            application.Configure(appRouteConfig);
            application.InitializeDatabase();

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<GameStoreDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
