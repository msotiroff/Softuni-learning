namespace CustomHttpServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class PostRequestHandler : RequestHandler
    {
        public PostRequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunction) 
            : base(handlingFunction)
        {
        }
    }
}
