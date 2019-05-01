namespace P01.ReverseNumbers
{
    using System.Collections.Generic;

    public static class CollectionExtenssions
    {
        public static Stack<T> ToStack<T>(this IEnumerable<T> collection)
        {
            return new Stack<T>(collection);
        }
    }
}
