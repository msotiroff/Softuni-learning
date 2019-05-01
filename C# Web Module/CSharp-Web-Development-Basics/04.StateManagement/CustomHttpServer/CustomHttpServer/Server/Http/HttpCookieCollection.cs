namespace CustomHttpServer.Server.Http
{
    using Common;
    using Contracts;
    using System.Collections;
    using System.Collections.Generic;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        private const string KeyNotFoundExceptionMsg = "The given key {0} is not present in the cookies collection.";

        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        public void Add(HttpCookie cookie)
        {
            CommonValidator.ThrowIfNull(cookie, nameof(cookie));

            this.cookies[cookie.Key] = cookie;
        }

        public void Add(string key, string value)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CommonValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.cookies[key] = new HttpCookie(key, value);
        }

        public bool ContainsKey(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            return this.cookies.ContainsKey(key);
        }

        public HttpCookie Get(string key)
        {
            if (this.ContainsKey(key))
            {
                return this.cookies[key];
            }

            throw new KeyNotFoundException(string.Format(KeyNotFoundExceptionMsg, key));
        }

        public IEnumerator<HttpCookie> GetEnumerator()
            => this.cookies.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}
