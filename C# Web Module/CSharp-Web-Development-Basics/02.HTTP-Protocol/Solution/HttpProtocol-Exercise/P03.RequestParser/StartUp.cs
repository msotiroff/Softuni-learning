namespace P03.RequestParser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private const string NotFoundStatusCode = "404 Not Found";
        private const string NotFoundStatusText = "Not Found";
        private const string SuccessStatusCode = "200 OK";
        private const string SuccessStatusText = "OK";

        public static void Main()
        {
            // key:Method, value:Collection of Paths
            var validPaths = new Dictionary<string, HashSet<string>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputParams = inputLine
                    .Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var method = inputParams.Last().ToLower();
                inputParams.RemoveAt(inputParams.Count - 1);

                var path = $"/{string.Join('/', inputParams)}";

                if (!validPaths.ContainsKey(method))
                {
                    validPaths[method] = new HashSet<string>();
                }

                validPaths[method].Add(path);
            }

            var request = Console.ReadLine();

            var parsedRequest = request.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var httpMethod = parsedRequest[0].ToLower();
            var httpPath = parsedRequest[1];
            var httpVersion = parsedRequest[2];
            var statusText = SuccessStatusText;
            var statusCode = SuccessStatusCode;

            var pathIsValid = validPaths.ContainsKey(httpMethod) && validPaths[httpMethod].Contains(httpPath);

            if (!pathIsValid)
            {
                statusText = NotFoundStatusText;
                statusCode = NotFoundStatusCode;
            }

            var response = GetResponse(httpVersion, statusText, statusCode);

            Console.WriteLine(response);
        }

        private static string GetResponse(string httpVersion, string statusText, string statusCode)
            => $"{httpVersion} {statusCode}"
                + Environment.NewLine
                + $"Content-Length: {statusText.Length}"
                + Environment.NewLine
                + "Content-Type: text/plain"
                + Environment.NewLine
                + Environment.NewLine
                + statusText;
    }
}
