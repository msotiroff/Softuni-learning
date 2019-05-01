namespace P03.SimpleWebServer
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        private const string Ip = "127.0.0.1";
        private const int Port = 1300;

        public static void Main()
        {
            var addres = IPAddress.Parse(Ip);
            var listener = new TcpListener(addres, Port);
            listener.Start();

            Console.WriteLine("Server started.");
            Console.WriteLine($"Listening to TCP clients at {Ip}:{Port}");

            Task
                .Run(async () =>
                {
                    await ConnectWithTcpClient(listener);
                })
                .Wait();
        }

        private static async Task ConnectWithTcpClient(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Waiting for client...");
                
                using (var client = await listener.AcceptTcpClientAsync())
                {
                    Console.WriteLine("Client connected!");
                    Console.WriteLine();

                    byte[] buffer = new byte[1024];
                    await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                    string clientMessage = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(clientMessage.Trim('\0'));

                    var headers = "HTTP/1.1 200 OK\nContent-Type: text-plain\n\n";
                    string responseMessage = $"{headers}Hello from server!";
                    byte[] data = Encoding.UTF8.GetBytes(responseMessage);
                    await client.GetStream().WriteAsync(data, 0, data.Length);

                    Console.WriteLine("Closing connection!");
                }
            }
        }
    }
}
