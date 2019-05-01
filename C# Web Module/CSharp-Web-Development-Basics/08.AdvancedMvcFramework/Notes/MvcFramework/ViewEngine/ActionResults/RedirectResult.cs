namespace MvcFramework.ViewEngine.ActionResults
{
    using Interfaces;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class RedirectResult : IRedirectable
    {
        public RedirectResult(string redirectUrl)
        {
            this.RedirectUrl = redirectUrl;
        }

        public string RedirectUrl { get; }

        public IHttpResponse Invoke() => new RedirectResponse(this.RedirectUrl);
    }
}
