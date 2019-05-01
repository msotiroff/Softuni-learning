namespace SoftUniGameStore.App.Infrastructure.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AllowAnonymousAttribute : Attribute
    {
    }
}
