using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class SoftUniAttribute : Attribute
{
    private string name;
    
    public SoftUniAttribute(string name)
    {
        this.name = name;
    }
}
