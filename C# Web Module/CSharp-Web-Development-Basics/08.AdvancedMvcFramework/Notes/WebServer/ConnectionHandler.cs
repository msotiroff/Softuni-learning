namespace WebServer
{
    using Common;
    using Http;
    using Http.Contracts;
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;
    using System.Collections.Generic;
    using WebServer.Http.Response;
    using System.Linq;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly IHandleable mvcRequestHandler;
        private readonly IHandleable resourseHandler;

        public ConnectionHandler(Socket client, IHandleable mvcRequestHandler, IHandleable resourseHandler)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(mvcRequestHandler, nameof(mvcRequestHandler));
            CoreValidator.ThrowIfNull(resourseHandler, nameof(resourseHandler));

            this.client = client;
            this.mvcRequestHandler = mvcRequestHandler;
            this.resourseHandler = resourseHandler;
        }

        public async Task ProcessRequestAsync()
        {
            var request = await this.ReadRequest();

            if (request != null)
            {
                var response = this.HandleRequest(request);

                var responseBytes = this.GetResponseBytes(response);

                var byteSegments = new ArraySegment<byte>(responseBytes);

                await this.client.SendAsync(byteSegments, SocketFlags.None);

                Console.WriteLine($"-----REQUEST-----");
                Console.WriteLine(request);
                Console.WriteLine($"-----RESPONSE-----");
                Console.WriteLine(response);
                Console.WriteLine();
            }
            
            this.client.Shutdown(SocketShutdown.Both);
        }

        private IHttpResponse HandleRequest(IHttpRequest request)
        {
            if (request.Path.Contains("."))
            {
                return this.resourseHandler.Handle(request);
            }
            else
            {
                var sessionIdToSend = this.SetRequestSession(request);

                var response = this.mvcRequestHandler.Handle(request);

                this.SetResponseSession(response, sessionIdToSend);

                return response;
            }
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            
            var data = new ArraySegment<byte>(new byte[1024]);
            
            while (true)
            {
                int numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);

                result.Append(bytesAsString);

                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }
            
            return new HttpRequest(result.ToString());
        }

        private byte[] GetResponseBytes(IHttpResponse response)
        {
            List<byte> responseBytes = Encoding.UTF8.GetBytes(response.ToString()).ToList();

            if (response is FileResponse)
            {
                responseBytes.AddRange(((FileResponse)response).FileData);
            }

            return responseBytes.ToArray();
        }

        private string SetRequestSession(IHttpRequest request)
        {
            if (!request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                string sessionId = Guid.NewGuid().ToString();

                request.Session = SessionStore.Get(sessionId);

                return sessionId;
            }

            return null;
        }

        private void SetResponseSession(IHttpResponse response, string sessionIdToSend)
        {
            if (sessionIdToSend != null)
            {
                response.Headers.Add(
                    HttpHeader.SetCookie,
                    $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            }
        }
    }
}
