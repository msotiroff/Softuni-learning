namespace P09.HTTPServer
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Text;

    public class StartUp
    {
        public const string viewsDirectory = "../Resourses";
        public const int port = 8081;

        public static void Main()
        {
            HttpListener listener = new HttpListener();

            listener.Prefixes.Add($"http://127.0.0.1:{port}/");
            listener.Start();

            Console.WriteLine($"Listening on port: {port}");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                Console.WriteLine(context.Request.Url);

                HttpListenerResponse response = context.Response;
                string responseString = string.Empty;

                switch (context.Request.RawUrl.Substring(1))
                {
                    case "":
                        responseString = File.ReadAllText($"{viewsDirectory}/index.html");
                        break;

                    case "index":
                        responseString = File.ReadAllText($"{viewsDirectory}/index.html");
                        break;

                    case "info":
                        responseString = File.ReadAllText($"{viewsDirectory}/info.html");
                        responseString = responseString.Replace("{0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                        responseString = responseString.Replace("{1}", Environment.ProcessorCount.ToString());
                        break;

                    default:
                        responseString = File.ReadAllText("../Resourses/error.html");
                        break;
                }

                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;

                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
