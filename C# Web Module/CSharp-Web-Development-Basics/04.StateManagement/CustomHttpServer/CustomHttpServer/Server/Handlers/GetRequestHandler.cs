namespace CustomHttpServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class GetRequestHandler : RequestHandler
    {
        public GetRequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunction) 
            : base(handlingFunction)
        {
        }
    }
}
