namespace CustomHttpServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http;
    using Http.Contracts;
    using System;

    public abstract class RequestHandler : IRequestHandler
    {
        private const string TextHtml = "text/html";

        private readonly Func<IHttpRequest, IHttpResponse> handlingFunction;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunction)
        {
            CommonValidator.ThrowIfNull(handlingFunction, nameof(handlingFunction));

            this.handlingFunction = handlingFunction;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            string sessionIdToSend = null;

            if (!httpContext.Request.Cookies.ContainsKey(SessionRepository.SessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                httpContext.Request.Session = SessionRepository.Get(sessionId);

                sessionIdToSend = sessionId;
            }

            var response = this.handlingFunction.Invoke(httpContext.Request);

            if (sessionIdToSend != null)
            {
                var newHeader = new HttpHeader(HttpHeader.SetCookie,
                    $"{SessionRepository.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");

                response.HeaderCollection.Add(newHeader);
            }

            if (!response.HeaderCollection.ContainsKey(HttpHeader.ContentType))
            {
                var contentTypeHeader = new HttpHeader(HttpHeader.ContentType, "text/html");
                response.HeaderCollection.Add(contentTypeHeader);
            }

            foreach (var cookie in response.Cookies)
            {
                var newCookieHeader = new HttpHeader(HttpHeader.SetCookie, cookie.ToString());
                response.HeaderCollection.Add(newCookieHeader);
            }

            return response;
        }

        private void SetCookies(IHttpContext httpContext, IHttpResponse httpResponse)
        {
            var cookies = httpContext.Request.Cookies;
            foreach (HttpCookie cookie in cookies)
            {
                if (cookie.IsNew)
                {
                    httpResponse.AddHeader("Set-Cookie", cookie.ToString());
                }
            }
        }
    }
}
