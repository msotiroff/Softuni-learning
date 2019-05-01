namespace P02.ValidateURL
{
    using System;
    using System.Net;

    public class StartUp
    {
        private const string InvalidUrlErrorMsg = "Invalid URL";

        public static void Main()
        {
            string result;

            var inputUrl = Console.ReadLine();

            var decodedUrl = WebUtility.UrlDecode(inputUrl);
            
            try
            {
                var parsedUrl = new Uri(decodedUrl);

                //Required data:
                var protocol = parsedUrl.Scheme;
                var host = parsedUrl.Host;
                var port = parsedUrl.Port.ToString();
                var path = parsedUrl.AbsolutePath;

                // Optional data:
                var queryString = parsedUrl.Query.TrimStart('?');
                var fragment = parsedUrl.Fragment.TrimStart('#');

                var isValid = ValidateUri(protocol, host, port, path);

                if (!isValid)
                {
                    result = InvalidUrlErrorMsg;
                }
                else
                {
                    result = FormUriResult(protocol, host, port, path, queryString, fragment);
                }
            }
            catch (UriFormatException)
            {
                result = InvalidUrlErrorMsg;
            }
            
            Console.WriteLine(result);
        }

        private static bool ValidateUri(string protocol, string host, string port, string path)
        {
            if (string.IsNullOrEmpty(protocol)
                || string.IsNullOrEmpty(host)
                || port == "0"
                || string.IsNullOrEmpty(path))
            {
                return false;
            }
            if (protocol != "http" && protocol != "https")
            {
                return false;
            }
            if (protocol == "http" && !port.StartsWith("80"))
            {
                return false;
            }
            if (protocol == "https" && !port.StartsWith("443"))
            {
                return false;
            }

            return true;
        }

        private static string FormUriResult(string protocol, string host, string port, string path, string queryString, string fragment)
        {
            var result = $"Protocol: {protocol}"
                            + Environment.NewLine
                            + $"Host: {host}"
                            + Environment.NewLine
                            + $"Port: {port}"
                            + Environment.NewLine
                            + $"Path: {path}";

            if (!string.IsNullOrEmpty(queryString))
            {
                result += Environment.NewLine + $"Query: {queryString}";
            }
            if (!string.IsNullOrEmpty(fragment))
            {
                result += Environment.NewLine + $"Fragment: {fragment}";
            }

            return result;
        }
    }
}
