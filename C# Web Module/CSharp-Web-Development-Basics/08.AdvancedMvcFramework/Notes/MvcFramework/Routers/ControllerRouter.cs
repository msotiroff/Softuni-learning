namespace MvcFramework.Routers
{
    using Attributes.Methods;
    using Controllers;
    using Infrastructure.Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using WebServer.Contracts;
    using WebServer.Http.Contracts;
    using WebServer.Http.Response;

    public class ControllerRouter : IHandleable
    {
        public IHttpResponse Handle(IHttpRequest request)
        {
            var requestMethod = request.Method.ToString();

            var allControllerParameters = request
                .Path
                .Split('/')
                .ToArray();

            var controllerParameters = allControllerParameters
                .Skip(allControllerParameters.Length - 2)
                .Take(2)
                .ToArray();

            var controllerName = controllerParameters[0].ToTitleCase() + MvcContext.Get.ControllersSuffix;
            var actionName = controllerParameters[1].ToTitleCase();

            var controller = this.GetControllerInstance(controllerName);

            if (controller != null)
            {
                controller.Request = request;
                controller.InitializeController();
            }

            var method = this.GetMethodForExecution(controller, requestMethod, actionName);
            if (method == null)
            {
                return new NotFoundResponse();
            }

            var parameters = method.GetParameters();
            var getParameters = request.UrlParameters;
            var postParameters = request.FormData;

            var methodParameters = this.InjectMethodParameters(parameters, getParameters, postParameters);

            try
            {
                IHttpResponse response = this.GetResponse(method, controller, methodParameters);

                return response;
            }
            catch (Exception ex)
            {
                return new InternalServerErrorResponse(ex);
            }
        }

        protected virtual Controller GetControllerInstance(string controllerName)
        {
            Controller controllerInstance = null;

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

            controllerInstance = (Controller)Activator.CreateInstance(controllerType);

            return controllerInstance;
        }

        private IHttpResponse GetResponse(MethodInfo method, Controller controller, object[] methodParameters)
        {
            var actionResult = method
                .Invoke(controller, methodParameters) as IActionResult;

            if (actionResult == null)
            {
                var httpResponse = actionResult as IHttpResponse;

                if (httpResponse != null)
                {
                    return httpResponse;
                }
            }

            return actionResult.Invoke();
        }

        private object[] InjectMethodParameters(
            ParameterInfo[] parameters,
            IDictionary<string, string> getParameters,
            IDictionary<string, string> postParameters)
        {
            var methodParameters = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];

                if (parameter.ParameterType.IsPrimitive || parameter.ParameterType == typeof(string))
                {
                    methodParameters[i] = this.ProcessPrimitiveParameter(parameter, getParameters);
                }
                else
                {
                    methodParameters[i] = this.ProcessComplexParameter(parameter, postParameters);
                }
            }

            return methodParameters;
        }

        private object ProcessComplexParameter(ParameterInfo parameter, IDictionary<string, string> postParameters)
        {
            var modelType = parameter.ParameterType;

            var modelInstance = Activator.CreateInstance(modelType);

            var modelProperties = modelType.GetProperties();

            foreach (var property in modelProperties)
            {
                var postParameterValue = postParameters[property.Name];

                var value = Convert
                    .ChangeType(postParameterValue, property.PropertyType);

                property.SetValue(modelInstance, value);
            }

            var methodParameter = Convert.ChangeType(modelInstance, modelType);

            return methodParameter;
        }

        private object ProcessPrimitiveParameter(ParameterInfo parameter, IDictionary<string, string> getParameters)
        {
            var getParameterValue = getParameters[parameter.Name];

            var value = Convert.ChangeType(
                getParameterValue,
                parameter.ParameterType);

            return value;
        }

        private MethodInfo GetMethodForExecution(Controller controller, string requestMethod, string actionName)
        {
            foreach (var method in this.GetMatchedMethods(controller, actionName))
            {
                var httpMethodAttribute = method.GetCustomAttribute<HttpMethodAttribute>();

                if (httpMethodAttribute != null && httpMethodAttribute.IsValid(requestMethod))
                {
                    return method;
                }
            }

            return null;
        }

        private IEnumerable<MethodInfo> GetMatchedMethods(Controller controller, string actionName)
        {
            if (controller == null)
            {
                return new MethodInfo[0];
            }

            var methods = controller
                .GetType()
                .GetMethods()
                .Where(m => m.Name == actionName);

            return methods;
        }
    }
}
