namespace CustomHttpServer.Server.Routing.Contracts
{
    using Handlers.Contracts;
    using System.Collections.Generic;

    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        IRequestHandler RequestHandler { get; }
    }
}
