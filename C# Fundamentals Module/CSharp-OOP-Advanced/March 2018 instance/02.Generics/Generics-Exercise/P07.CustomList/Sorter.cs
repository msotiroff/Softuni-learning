using System;
using System.Linq;

public class Sorter
{
    public static CustomList<T> Sort<T>(CustomList<T> collection) where T : IComparable<T>
    {
        var ordered = collection.Elements.OrderBy(x => x).ToList();

        return new CustomList<T>(ordered);
    }
}
