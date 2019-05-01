namespace CustomHttpServer.Server.Routing.Contracts
{
    using Http.Enums;
    using System.Collections.Generic;

    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}
