namespace Notes.App.Infrastructure
{
    using MvcFramework;
    using MvcFramework.Controllers;
    using MvcFramework.Routers;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DependencyControllerRouter : ControllerRouter
    {
        private readonly IServiceProvider container;

        public DependencyControllerRouter(IServiceProvider container)
        {
            this.container = container;
        }

        protected override Controller GetControllerInstance(string controllerName)
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                controllerName);

            var controllerType = Type.GetType(controllerFullQualifiedName);

            if (controllerType == null)
            {
                return null;
            }

            var dependencies = this.GetDependencies(controllerType);

            var controllerInstance = (Controller)Activator.CreateInstance(controllerType, dependencies);

            return controllerInstance;
        }

        private object[] GetDependencies(Type controllerType)
        {
            var constructorParameters = controllerType
                .GetConstructors()
                .First()
                .GetParameters();

            var dependencies = new List<object>();

            foreach (var parameter in constructorParameters)
            {
                var parameterType = parameter.ParameterType;

                try
                {
                    var dependency = this.container.GetService(parameterType);

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

            return dependencies.ToArray();
        }
    }
}
