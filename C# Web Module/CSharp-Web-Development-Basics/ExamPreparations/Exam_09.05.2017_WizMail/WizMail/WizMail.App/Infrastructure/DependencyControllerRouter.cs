namespace WizMail.App.Infrastructure
{
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Routers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Http.Contracts;

    public class DependencyControllerRouter : ControllerRouter
    {
        private const string ControllersFolder = "Controllers";

        private IServiceProvider container;

        public DependencyControllerRouter(IServiceProvider container)
        {
            this.container = container;
        }

        /// <summary>
        /// IMPORTANT: GetController method in the inherited ControllerRouter should be virtual, 
        /// in order to be overridden in this router and all constructor dependencies to be injected in the returned Controller!
        /// </summary>
        /// <param name="controllerName"></param>
        /// <param name="request"></param>
        /// <returns>Controller</returns>
        protected override Controller GetController(string controllerName, IHttpRequest request)
        {
            var entryAssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            var controllerFullName = $"{entryAssemblyName}.{ControllersFolder}.{controllerName}";

            var controllerType = Type.GetType(controllerFullName);

            var dependencies = this.GetDependencies(controllerType);

            var controller = Activator.CreateInstance(controllerType, dependencies) as Controller;

            if (controller != null)
            {
                controller.Request = request;
                controller.OnAuthentication();
            }

            return controller;
        }

        private object[] GetDependencies(Type controllerType)
        {
            var dependencies = new List<object>();

            var constructorParameters = controllerType
                .GetConstructors()
                .First()
                .GetParameters();

            foreach (var parameter in constructorParameters)
            {
                var parameterType = parameter.ParameterType;

                try
                {
                    var dependency = this.container.GetService(parameterType);
                    dependencies.Add(dependency);
                }
                catch
                {
                    continue;
                }
            }

            return dependencies.ToArray();
        }
    }
}
