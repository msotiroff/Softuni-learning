namespace SoftUniGameStore.App
{
    using Controllers;
    using Data;
    using HTTPServer.Contracts;
    using HTTPServer.Enums;
    using HTTPServer.Http.Contracts;
    using HTTPServer.Http.Response;
    using HTTPServer.Routing.Contracts;
    using Infrastructure.Attributes;
    using Infrastructure.Extensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class GameStoreApp : IApplication
    {
        private const string ControllerSuffix = "Controller";

        private readonly IServiceProvider serviceProvider;

        public GameStoreApp(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Configure(IAppRouteConfig appRouteConfig)
        {
            // Anonymous routes:
            this.ConfigureAnonymousRoutes(appRouteConfig);
            
            // All other routes by template => {controller}/{action}
            this.ConfigureControllerRoutes(appRouteConfig);

            // File allowed folders:
            appRouteConfig.AllowedFolders.Add("/wwwroot");

            // Home page redirect:
            appRouteConfig
                .Get("/", req => new RedirectResponse("Home/Index"));
        }

        public void InitializeDatabase()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.Migrate();

                db.AddDefaultRoles();
            }
        }

        private void ConfigureAnonymousRoutes(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AnonymousPaths.Add("/");

            var controllers = Assembly
                            .GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.Name.EndsWith(ControllerSuffix) && !t.IsAbstract);

            foreach (var controller in controllers)
            {
                var controllerRoute = controller.Name.Replace(ControllerSuffix, string.Empty);

                var anonymoysMethods = controller
                    .GetMethods()
                    .Where(mi => mi.GetCustomAttribute<AllowAnonymousAttribute>() != null);

                foreach (var method in anonymoysMethods)
                {
                    var actionRoute = method.Name;

                    appRouteConfig.AnonymousPaths.Add($"/{controllerRoute}/{actionRoute}");
                }
            }
        }

        private void ConfigureControllerRoutes(IAppRouteConfig appRouteConfig)
        {
            var controllers = Assembly
                            .GetExecutingAssembly()
                            .GetTypes()
                            .Where(t => t.Name.EndsWith(ControllerSuffix) && !t.IsAbstract);

            foreach (var controller in controllers)
            {
                var methods = controller.GetMethods();

                foreach (var method in methods)
                {
                    var reqMethodAttribute = method.GetCustomAttribute<RequestMethodAttribute>();

                    if (reqMethodAttribute == null)
                    {
                        continue;
                    }

                    var requestMethod = reqMethodAttribute.RequestMethod;

                    var controllerRoute = controller.Name.Replace(ControllerSuffix, string.Empty);
                    var actionRoute = method.Name;

                    switch (requestMethod)
                    {
                        case HttpRequestMethod.Get:
                            appRouteConfig.Get($"/{controllerRoute}/{actionRoute}",
                                req => (HttpResponse)method
                                    .Invoke(this.GetControllerInstance(controller, req), null));
                            break;
                        case HttpRequestMethod.Post:
                            appRouteConfig.Post($"/{controllerRoute}/{actionRoute}",
                                req => (HttpResponse)method
                                    .Invoke(this.GetControllerInstance(controller, req), null));
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private BaseController GetControllerInstance(Type controller, IHttpRequest req)
        {
            var constructorParameters = controller
                .GetConstructors()
                .First()
                .GetParameters();

            var dependencies = new List<object>();
            dependencies.Add(req);

            foreach (var parameter in constructorParameters)
            {
                try
                {
                    var dependency = this.serviceProvider.GetService(parameter.ParameterType ?? null);

                    if (dependency != null)
                    {
                        dependencies.Add(dependency);
                    }
                }
                catch
                {
                    continue;
                }
            }

            var instance = (BaseController)Activator.CreateInstance(controller, dependencies.ToArray());

            return instance;
        }
    }
}