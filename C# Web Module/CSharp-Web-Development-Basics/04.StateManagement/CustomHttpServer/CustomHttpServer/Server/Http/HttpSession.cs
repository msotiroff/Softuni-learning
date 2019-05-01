namespace CustomHttpServer.Server.Http
{
    using Common;
    using Contracts;
    using System.Collections.Generic;

    public class HttpSession : IHttpSession
    {
        private const string KeyNotFoundExceptionMsg = "The given key {0} is not present in the cookies collection.";
        
        private IDictionary<string, string> parameters;

        public HttpSession(string id)
        {
            this.parameters = new Dictionary<string, string>();
            this.Id = id;
        }

        public string Id { get; private set; }

        public void Add(string key, string value)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CommonValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.parameters[key] = value;
        }

        public void Clear() => this.parameters.Clear();

        public string GetParameter(string key)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));

            if (this.parameters.ContainsKey(key))
            {
                return this.parameters[key];
            }

            throw new KeyNotFoundException(string.Format(KeyNotFoundExceptionMsg, key));
        }
    }
}
