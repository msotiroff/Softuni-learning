namespace CustomHttpServer.Server
{
    using Contracts;
    using Routing;
    using Routing.Contracts;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class WebServer : IRunnable
    {
        private const string IpAddress = "127.0.0.1";
        private const string ServerStartedMsg = "Server started. Listening to TCP clients at {0}:{1}";

        private readonly int port;
        private readonly IServerRouteConfig serverRouteConfig;
        private readonly TcpListener tcpListener;
        private bool isRunning;

        public WebServer(int port, IAppRouteConfig appRouteConfig)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse(IpAddress), port);
            this.serverRouteConfig = new ServerRouteConfig(appRouteConfig);
        }

        public void Run()
        {
            this.isRunning = true;

            this.tcpListener.Start();

            Console.WriteLine(string.Format(ServerStartedMsg, IpAddress, this.port));

            Task
                .Run(this.ListenLoop)
                .Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.tcpListener.AcceptSocketAsync();

                var connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);

                var connection = connectionHandler.ProcessRequestAsync();

                connection.Wait();
            }
        }
    }
}
