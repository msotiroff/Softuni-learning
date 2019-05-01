namespace P02.ParseURLs
{
    using System;

    public class ParseURLs
    {
        public static void Main(string[] args)
        {
            var result = string.Empty;

            var inputLine = Console.ReadLine();

            var firstIndexOfProtocol = inputLine.IndexOf(@"://");
            var lastIndexOfProtokol = inputLine.LastIndexOf(@"://");

            if (firstIndexOfProtocol != lastIndexOfProtokol || firstIndexOfProtocol == -1)
            {
                result = "Invalid URL";
            }
            else
            {
                var protocol = inputLine.Substring(0, firstIndexOfProtocol);
                result = $"Protocol = {protocol}{Environment.NewLine}";

                inputLine = inputLine.Substring(firstIndexOfProtocol + 3);

                var serverLastIndex = inputLine.IndexOf("/");

                if (serverLastIndex == -1)
                {
                    result = "Invalid URL";
                }
                else
                {
                    var server = inputLine.Substring(0, serverLastIndex);
                    var resources = inputLine.Substring(serverLastIndex + 1);

                    result += $"Server = {server}{Environment.NewLine}Resources = {resources}";
                }
            }

            Console.WriteLine(result);
        }
    }
}
