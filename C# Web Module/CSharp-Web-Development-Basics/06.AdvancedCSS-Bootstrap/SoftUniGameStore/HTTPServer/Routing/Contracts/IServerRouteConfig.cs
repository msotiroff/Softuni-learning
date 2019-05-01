namespace HTTPServer.Routing.Contracts
{
    using Enums;
    using System.Collections.Generic;

    public interface IServerRouteConfig
    {
        string ApplicationDirectory { get; }

        IDictionary<HttpRequestMethod, IDictionary<string, IRoutingContext>> Routes { get; }

        ICollection<string> AnonymousPaths { get; }

        ICollection<string> AllowedFolders { get; }
    }
}
