using System;

[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Class, AllowMultiple = false)]
public class TypeAttribute : Attribute
{
    private string type;
    private string category;
    private string description;

    public TypeAttribute(string type, string category, string description)
    {
        this.type = type;
        this.category = category;
        this.description = description;
    }

    public override string ToString()
    {
        return $"Type = {this.type}, Description = {this.description}.";
    }
}
