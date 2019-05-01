namespace CustomHttpServer.Server.Http.Contracts
{
    using Enums;

    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection HeaderCollection { get; }

        IHttpCookieCollection Cookies { get; }
        
        string StatusMessage { get; }

        string Response { get; }

        void AddHeader(string location, string redirectUrl);
    }
}
