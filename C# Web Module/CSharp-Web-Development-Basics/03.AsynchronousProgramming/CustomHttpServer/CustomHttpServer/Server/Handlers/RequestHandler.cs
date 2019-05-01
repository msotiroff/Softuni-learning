namespace CustomHttpServer.Server.Handlers
{
    using Common;
    using Contracts;
    using Http.Contracts;
    using System;

    public abstract class RequestHandler : IRequestHandler
    {
        private const string ContentType = "Content-Type";
        private const string ContentValue = "text/html";

        private readonly Func<IHttpRequest, IHttpResponse> handlingFunction;

        protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunction)
        {
            CommonValidator.ThrowIfNull(handlingFunction, nameof(handlingFunction));

            this.handlingFunction = handlingFunction;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            var response = this.handlingFunction.Invoke(httpContext.Request);

            response.AddHeader(ContentType, ContentValue);

            return response;
        }
    }
}
