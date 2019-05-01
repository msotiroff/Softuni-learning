using RecyclingStation.WasteDisposal.Attributes;
using System;

namespace RecyclingStation.Extensions.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StorableAttribute : DisposableAttribute
    {
    }
}
