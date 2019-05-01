namespace CustomHttpServer
{
    using Application;
    using Server;
    using Server.Contracts;
    using Server.Routing;

    public class Launcher : IRunnable
    {
        private const int port = 8230;

        private WebServer webServer;

        public static void Main()
        {
            new Launcher().Run();
        }

        public void Run()
        {
            var routeConfig = new AppRouteConfig();

            var app = new MainApplication();
            app.Start(routeConfig);
            
            this.webServer = new WebServer(port, routeConfig);
            this.webServer.Run();
        }
    }
}
