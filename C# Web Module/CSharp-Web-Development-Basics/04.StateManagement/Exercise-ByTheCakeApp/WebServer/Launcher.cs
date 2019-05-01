namespace HTTPServer
{
    using ByTheCakeApplication;
    using Server;
    using Server.Routing;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            Run(args);
        }

        private static void Run(string[] args)
        {
            var application = new ByTheCakeApp();

            var appRouteConfig = new AppRouteConfig();
            application.Configure(appRouteConfig);

            var server = new WebServer(8000, appRouteConfig);

            server.Run();
        }
    }
}
