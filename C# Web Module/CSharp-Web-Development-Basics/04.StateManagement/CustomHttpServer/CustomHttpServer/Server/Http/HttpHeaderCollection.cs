namespace CustomHttpServer.Server.Http
{
    using Common;
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HashSet<HttpHeader>> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HashSet<HttpHeader>>();
        }

        public void Add(HttpHeader header)
        {
            CommonValidator.ThrowIfNull(header, nameof(header));

            var key = header.Key;

            if (!this.headers.ContainsKey(key))
            {
                this.headers[key] = new HashSet<HttpHeader>();
            }

            this.headers[key].Add(header);
        }
        public void Add(string key, string value) 
            => this.Add(new HttpHeader(key, value));

        public bool ContainsKey(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.headers.ContainsKey(key);
        }

        public ICollection<HttpHeader> GetHeader(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (this.headers.ContainsKey(key))
            {
                return this.headers[key];
            }

            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
            

        public IEnumerator<ICollection<HttpHeader>> GetEnumerator()
            => this.headers.Values.GetEnumerator();

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var header in this.headers)
            {
                var headerKey = header.Key;

                foreach (var headerValue in header.Value)
                {
                    result.AppendLine($"{headerKey}: {headerValue.Value}");
                }
            }

            return result.ToString();
        }
    }
}
