namespace InfernoInfinity.Extensions.CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute : Attribute
    {
    }
}
