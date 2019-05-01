namespace BashSoft.App.Extensions.CustomCollections
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleSortedList<T> : ISimpleSortedBag<T>
        where T : IComparable<T>
    {
        private const int DefaultSize = 16;
        private const string InvalidCapacity = "Capacity cannot be negative!";
        private const string NullElementErrorMessage = "Value cannot be null";

        private T[] innerCollection;
        private int size;
        private IComparer<T> comparison;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.comparison = comparer;
            this.InitializeInnerCollection(capacity);
        }
        
        public SimpleSortedList(int capacity)
                : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {
        }

        public SimpleSortedList(IComparer<T> comparer)
            : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList()
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), DefaultSize)
        {
        }

        public int Size => this.size;

        public int Capacity => this.innerCollection.Length;

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(NullElementErrorMessage);
            }

            if (this.innerCollection.Length == this.size)
            {
                this.Resize();
            }

            this.innerCollection[size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public void AddAll(ICollection<T> collection)
        {
            if (this.Size + collection.Count > this.innerCollection.Length)
            {
                this.MultiResize(collection);
            }

            foreach (var element in collection)
            {
                if (element == null)
                {
                    throw new ArgumentNullException(NullElementErrorMessage);
                }

                this.innerCollection[this.size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.size, this.comparison);
        }

        public string JoinWith(string joiner)
        {
            if (joiner != null)
            {
                return string.Join(joiner, this.innerCollection.Where(e => e != null));
            }

            throw new ArgumentNullException(NullElementErrorMessage);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Resize()
        {
            Array.Resize(ref this.innerCollection, this.innerCollection.Length * 2);
        }

        private void MultiResize(ICollection<T> collection)
        {
            int newSize = this.innerCollection.Length * 2;

            while (this.Size + collection.Count >= newSize)
            {
                newSize *= 2;
            }

            T[] newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.size);
            this.innerCollection = newCollection;
        }

        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException(InvalidCapacity);
            }

            this.innerCollection = new T[capacity];
        }

        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(NullElementErrorMessage);
            }

            var isElementRemoved = false;
            var indexOfElementToBeRemoved = 0;
            for (int i = 0; i < this.Capacity; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfElementToBeRemoved = i;
                    this.innerCollection[indexOfElementToBeRemoved] = default(T);
                    this.size--;
                    isElementRemoved = true;
                    break;
                }
            }

            if (isElementRemoved)
            {
                for (int i = indexOfElementToBeRemoved; i < this.Capacity - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.size] = default(T);
            }

            return isElementRemoved;
        }

        public T this[int index] => this.innerCollection[index];
    }
}
