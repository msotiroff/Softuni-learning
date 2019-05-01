namespace CustomHttpServer.Server.Http.Response
{
    using Common;
    using Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl) 
        {
            CommonValidator.ThrowIfNull(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader(HttpHeader.Location, redirectUrl);
        }
    }
}
