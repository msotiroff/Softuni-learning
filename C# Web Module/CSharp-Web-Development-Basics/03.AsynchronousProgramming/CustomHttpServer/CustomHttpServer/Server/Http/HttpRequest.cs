namespace CustomHttpServer.Server.Http
{
    using Contracts;
    using Enums;
    using Infrastructure.Extensions.CustomExceptions;
    using System;
    using System.Collections.Generic;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        #region Constants
        private const int RequestTopLineRequiredLength = 3;
        private const string HttpRequiredVersion = "http/1.1";
        private const string Host = "Host";
        #endregion

        #region Constructors
        public HttpRequest(string requestString)
        {
            this.InitializeCollections();

            this.ParseRequest(requestString);
        }
        #endregion

        #region Properties
        public IDictionary<string, string> FormData { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        public IDictionary<string, string> QueryParameters { get; private set; }

        public IHttpHeaderCollection HeaderCollection { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Path { get; private set; }

        public string Url { get; private set; }
        #endregion

        #region Public Methods
        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }
        #endregion

        #region Private Methods
        private void ParseRequest(string requestString)
        {
            //  Request format:
            /*  {Method} {URL} HTTP/1.1
                {Headers}
                {Empty line}
                {Form Data}
            */

            var requestLines = requestString
                .Split(Environment.NewLine);

            var firstLine = requestLines[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.ValidateRequest(firstLine);

            this.RequestMethod = this.ParseRequestMethod(firstLine[0].ToUpper());

            this.Url = firstLine[1];

            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];

            this.ParseHeaders(requestLines);

            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                var requestFormData = requestLines[requestLines.Length - 1];
                this.ParseQuery(requestFormData, this.FormData);
            }
        }

        private void ParseParameters()
        {
            if (this.Url.Contains("/"))
            {
                return;
            }

            var query = this.Url.Split('/')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, IDictionary<string, string> dictionary)
        {
            if (!query.Contains("="))
            {
                return;
            }

            var queryKVPs = query.Split('&');

            foreach (var kvp in queryKVPs)
            {
                var queryArgs = kvp.Split("=");
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                var key = WebUtility.UrlDecode(queryArgs[0]);
                var value = WebUtility.UrlDecode(queryArgs[1]);

                dictionary.Add(key, value);
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            var endIndex = Array.IndexOf(requestLines, string.Empty);

            for (int i = 1; i < endIndex; i++)
            {
                var headerArgs = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                if (headerArgs.Length == 2)
                {
                    var header = new HttpHeader(headerArgs[0], headerArgs[1]);
                    this.HeaderCollection.Add(header);
                }

                if (!this.HeaderCollection.ContainsKey(Host))
                {
                    throw new MissingHostException();
                }
            }
        }

        private HttpRequestMethod ParseRequestMethod(string value)
        {
            if (Enum.TryParse(value, out HttpRequestMethod requestMethod))
            {
                return requestMethod;
            }

            throw new InvalidRequestMethodException();
        }

        private void ValidateRequest(string[] firstLine)
        {
            if (firstLine.Length != RequestTopLineRequiredLength
                || firstLine[2].ToLower() != HttpRequiredVersion)
            {
                throw new BadRequestException();
            }
        }

        private void InitializeCollections()
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.FormData = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
        }
        #endregion
    }
}
