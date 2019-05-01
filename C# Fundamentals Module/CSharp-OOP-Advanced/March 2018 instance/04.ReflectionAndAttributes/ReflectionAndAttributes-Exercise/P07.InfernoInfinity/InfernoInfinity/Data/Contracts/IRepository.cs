namespace InfernoInfinity.Data.Contracts
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IList<T> Data { get; }

        void Add(T item);
    }
}
