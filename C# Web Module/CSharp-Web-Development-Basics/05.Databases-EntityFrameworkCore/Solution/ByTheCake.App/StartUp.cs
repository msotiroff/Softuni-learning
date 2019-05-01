namespace ByTheCake.App
{
    using System;
    using ByTheCake.Data;
    using HTTPServer;
    using HTTPServer.Routing;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            InitializeDatabase();
            
            var appRouteConfig = new AppRouteConfig();

            var appConfiguration = new ByTheCakeAppConfiguration();
            appConfiguration.Configure(appRouteConfig);

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }

        private static void InitializeDatabase()
        {
            using (var db = new ByTheCakeDbContext())
            {
                db.Database.EnsureCreated();
                db.Database.Migrate();
            }
        }
    }
}
