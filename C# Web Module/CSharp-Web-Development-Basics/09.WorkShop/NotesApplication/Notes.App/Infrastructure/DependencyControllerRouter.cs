namespace Notes.App.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Routers;

    public class DependencyControllerRouter : ControllerRouter
    {
        private IServiceProvider container;

        public DependencyControllerRouter(IServiceProvider container)
        {
            this.container = container;
        }

        protected override Controller CreateController(Type controllerType)
        {
            var dependencies = this.GetDependencies(controllerType);

            var controller = Activator.CreateInstance(controllerType, dependencies) as Controller;

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
