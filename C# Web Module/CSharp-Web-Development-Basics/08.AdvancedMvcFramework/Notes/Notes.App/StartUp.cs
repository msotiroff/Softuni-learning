namespace Notes.App
{
    using Data;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using MvcFramework;
    using MvcFramework.Routers;
    using Infrastructure;
    using System;
    using WebServer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var container = ConfigureServices();

            var server = new HttpServer(8000, new DependencyControllerRouter(container), new ResourceRouter());

            var mvcEngine = new MvcEngine();

            mvcEngine.Run(server);
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<DbContext, NotesDbContext>();

            services.AddDomainServices();

            return services.BuildServiceProvider();
        }
    }
}
