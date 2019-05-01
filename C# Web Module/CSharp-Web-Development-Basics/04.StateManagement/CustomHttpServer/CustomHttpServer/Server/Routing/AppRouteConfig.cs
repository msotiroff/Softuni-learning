namespace CustomHttpServer.Server.Routing
{
    using Contracts;
    using Handlers.Contracts;
    using Http.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AppRouteConfig : IAppRouteConfig
    {
        private const string GetMethodName = "get";
        private const string PostMethodName = "post";

        private Dictionary<HttpRequestMethod, Dictionary<string, IRequestHandler>> routes;

        public AppRouteConfig()
        {
            this.routes = new Dictionary<HttpRequestMethod, Dictionary<string, IRequestHandler>>();
            this.AddDefaultRequestMethods();
        }
        
        public IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, IRequestHandler>> Routes => this.routes;

        public void AddRoute(string route, IRequestHandler requestHandler)
        {
            var methodName = requestHandler.GetType().ToString().ToLower();

            if (methodName.Contains(GetMethodName))
            {
                this.routes[HttpRequestMethod.GET].Add(route, requestHandler);
            }
            else if (methodName.Contains(PostMethodName))
            {
                this.routes[HttpRequestMethod.POST].Add(route, requestHandler);
            }
        }

        private void AddDefaultRequestMethods()
        {
            var defaultRequestMethods = Enum.GetValues(typeof(HttpRequestMethod)).Cast<HttpRequestMethod>();

            foreach (var reqMethod in defaultRequestMethods)
            {
                this.routes.Add(reqMethod, new Dictionary<string, IRequestHandler>());
            }
        }
    }
}
