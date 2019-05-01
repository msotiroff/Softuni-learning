namespace CustomHttpServer.Server.Http
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            CommonValidator.ThrowIfNull(header, nameof(header));

            var key = header.Key;

            this.headers[key] = header;
        }

        public bool ContainsKey(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (this.headers.ContainsKey(key))
            {
                return this.headers[key];
            }

            return null;
        }

        public override string ToString()
            => string.Join(Environment.NewLine, this.headers.Values);
    }
}
