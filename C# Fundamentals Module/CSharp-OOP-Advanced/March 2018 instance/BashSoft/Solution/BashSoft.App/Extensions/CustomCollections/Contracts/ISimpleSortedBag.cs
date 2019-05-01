namespace BashSoft.App.Extensions.CustomCollections.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleSortedBag<T> : IEnumerable<T> 
        where T : IComparable<T>
    {
        void Add(T element);
        
        void AddAll(ICollection<T> collection);

        bool Remove(T element);

        int Capacity { get; }

        int Size { get; }

        string JoinWith(string joiner);

        T this[int index] { get; }
    }
}
