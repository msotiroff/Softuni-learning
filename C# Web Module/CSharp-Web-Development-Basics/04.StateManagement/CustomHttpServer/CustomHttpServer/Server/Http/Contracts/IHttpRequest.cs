namespace CustomHttpServer.Server.Http.Contracts
{
    using CustomHttpServer.Server.Http.Enums;
    using System.Collections.Generic;

    public interface IHttpRequest
    {
        IDictionary<string, string> FormData { get; }

        IDictionary<string, string> UrlParameters { get; }

        IDictionary<string, string> QueryParameters { get; }

        IHttpHeaderCollection HeaderCollection { get; }

        IHttpCookieCollection Cookies { get; }

        IHttpSession Session { get; set; }

        HttpRequestMethod RequestMethod { get; }

        string Path { get; }

        string Url { get; }

        void AddUrlParameter(string key, string value);

        void SetSession(Dictionary<string, IHttpSession> session);
    }
}
