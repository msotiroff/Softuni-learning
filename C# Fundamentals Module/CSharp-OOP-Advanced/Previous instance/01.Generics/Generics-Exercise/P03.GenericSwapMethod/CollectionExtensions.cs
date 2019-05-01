using System.Collections.Generic;

public static class CollectionExtensions
{
    public static List<T> SwapElements<T> (this List<T> collection, int firstElementIndex, int secondElementIndex)
    {
        var firstElement = collection[firstElementIndex];

        collection[firstElementIndex] = collection[secondElementIndex];
        collection[secondElementIndex] = firstElement;

        return collection;
    }
}