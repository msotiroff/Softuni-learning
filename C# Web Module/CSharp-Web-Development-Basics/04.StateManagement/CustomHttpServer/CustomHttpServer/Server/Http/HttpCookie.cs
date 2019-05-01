namespace CustomHttpServer.Server.Http
{
    using Common;
    using System;

    public class HttpCookie
    {
        public HttpCookie(string key, string value, int expirationDays = 3)
        {
            CommonValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CommonValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
            this.Expires = DateTime.UtcNow.AddDays(expirationDays);
        }

        public HttpCookie(string key, string value, bool isNew, int expirationDays = 3)
            : this(key, value, expirationDays)
        {
            this.IsNew = isNew;
        }

        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; } = true;

        public override string ToString()
            => $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";
    }
}
