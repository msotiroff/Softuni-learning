namespace HTTPServer.Routing.Contracts
{
    using Enums;
    using Handlers;
    using Http.Contracts;
    using System;
    using System.Collections.Generic;
    
    public interface IAppRouteConfig
    {
        string AppDirectory { get; }

        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        ICollection<string> AnonymousPaths { get; }

        ICollection<string> AllowedFolders { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);
    }
}
