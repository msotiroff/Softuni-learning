namespace SoftUniGameStore.App.Infrastructure.Attributes
{
    using HTTPServer.Enums;
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequestMethodAttribute : Attribute
    {
        public RequestMethodAttribute(HttpRequestMethod requestMethod)
        {
            this.RequestMethod = requestMethod;
        }

        public HttpRequestMethod RequestMethod { get; private set; }
    }
}
