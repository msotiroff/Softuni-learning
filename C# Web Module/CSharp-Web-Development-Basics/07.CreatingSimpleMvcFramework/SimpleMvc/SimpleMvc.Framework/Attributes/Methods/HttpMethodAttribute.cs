namespace SimpleMvc.Framework.Attributes.Methods
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid (string requestMethod);
    }
}
