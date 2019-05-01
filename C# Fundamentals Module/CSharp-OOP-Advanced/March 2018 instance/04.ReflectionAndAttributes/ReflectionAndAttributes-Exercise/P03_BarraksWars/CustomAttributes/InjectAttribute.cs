namespace P03_BarraksWars.CustomAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class InjectAttribute : Attribute
    {
    }
}
