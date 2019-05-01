namespace SimpleMvc.Framework.Routers
{
    using SimpleMvc.Framework.Attributes.Methods;
    using SimpleMvc.Framework.Controllers;
    using SimpleMvc.Framework.Infrastructure.Extensions;
    using SimpleMvc.Framework.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Enums;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParameters;
        private IDictionary<string, string> postParameters;
        private string requestMethod;
        private Controller controllerInstance;
        private string controllerName;
        private string actionName;
        private object[] methodParameters; 

        public IHttpResponse Handle(IHttpRequest request)
        {
            this.getParameters = request.UrlParameters;
            this.postParameters = request.FormData;
            this.requestMethod = request.Method.ToString();

            var successParsedRoute = this.TryParseRoute(request);
            if (!successParsedRoute)
            {
                return new NotFoundResponse();
            }

            var method = this.GetMethod();
            if (method == null)
            {
                return new NotFoundResponse();
            }

            this.RetrieveMethodParameters(method);
            
            var actionResult = (IInvocable)method.Invoke(this.controllerInstance, this.methodParameters);

            var content = actionResult.Invoke();

            var response = new ContentResponse(HttpStatusCode.Ok, content);

            return response;
        }

        private MethodInfo GetMethod()
        {
            foreach (var method in this.GetMatchedMethods())
            {
                var httpMethodAttribute = method.GetCustomAttribute<HttpMethodAttribute>();

                if (httpMethodAttribute != null && httpMethodAttribute.IsValid(this.requestMethod))
                {
                    return method;
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetMatchedMethods()
        {
            this.InitializeController();

            if (this.controllerInstance == null)
            {
                return new MethodInfo[0];
            }

            IEnumerable<MethodInfo> methods = this
                .controllerInstance
                .GetType()
                .GetMethods()
                .Where(m => m.Name == this.actionName);

            return methods;
        }

        private void InitializeController()
        {
            var controllerFullQualifiedName = string.Format(
                "{0}.{1}.{2}, {0}",
                MvcContext.Get.AssemblyName,
                MvcContext.Get.ControllersFolder,
                this.controllerName);

            var controllerType = Type.GetType(controllerFullQualifiedName);

            if (controllerType == null)
            {
                this.controllerInstance =  null;
            }

            this.controllerInstance = (Controller)Activator.CreateInstance(controllerType);
        }

        private bool TryParseRoute(IHttpRequest request)
        {
            var pathParts = request.Path.Split(new[] { '/', '?' }, StringSplitOptions.RemoveEmptyEntries);

            if (pathParts.Length < 2)
            {
                return false;
            }

            this.controllerName = $"{pathParts[0].ToTitleCase()}{MvcContext.Get.ControllersSuffix}";
            this.actionName = pathParts[1].ToTitleCase();

            return true;
        }

        private void RetrieveMethodParameters(MethodInfo method)
        {
            var parameters = method.GetParameters();

            this.methodParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];

                if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
                {
                    object getParameterValue = this.getParameters[parameter.Name];

                    object value = Convert.ChangeType(
                        getParameterValue,
                        parameter.ParameterType);

                    this.methodParameters[i] = value;
                }
                else
                {
                    var modelType = parameter.ParameterType;

                    var modelInstance = Activator.CreateInstance(modelType);

                    var modelProperties = modelType.GetProperties();

                    foreach (var property in modelProperties)
                    {
                        var postParameterValue = this.postParameters[property.Name];

                        var value = Convert
                            .ChangeType(postParameterValue, property.PropertyType);

                        property.SetValue(modelInstance, value);
                    }

                    this.methodParameters[i] = Convert.ChangeType(modelInstance, modelType);
                }
            }
        }
    }
}
