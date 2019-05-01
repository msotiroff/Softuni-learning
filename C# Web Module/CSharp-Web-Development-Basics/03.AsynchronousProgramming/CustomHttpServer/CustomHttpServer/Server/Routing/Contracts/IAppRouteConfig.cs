namespace CustomHttpServer.Server.Routing.Contracts
{
    using Handlers.Contracts;
    using Http.Enums;
    using System.Collections.Generic;

    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, IRequestHandler>> Routes { get; }

        void AddRoute(string route, IRequestHandler requestHandler);
    }
}
