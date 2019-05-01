namespace WebServer
{
    using Contracts;
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class HttpServer : IRunnable
    {
        private const string localHostIpAddress = "127.0.0.1";

        private readonly int port;
        private readonly IHandleable mvcRequestHandler;
        private readonly IHandleable resourseHandler;
        private readonly TcpListener listener;

        private bool isRunning;

        public HttpServer(int port, IHandleable mvcRequestHandler, IHandleable resourseHandler)
        {
            this.port = port;
            this.listener = new TcpListener(IPAddress.Parse(localHostIpAddress), port);

            this.mvcRequestHandler = mvcRequestHandler;
            this.resourseHandler = resourseHandler;
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server running on {localHostIpAddress}:{this.port}");

            Task.Run(this.ListenLoop).Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                var client = await this.listener.AcceptSocketAsync();
                var connectionHandler = new ConnectionHandler(client, this.mvcRequestHandler, this.resourseHandler);
                await connectionHandler.ProcessRequestAsync();
            }
        }
    }
}
