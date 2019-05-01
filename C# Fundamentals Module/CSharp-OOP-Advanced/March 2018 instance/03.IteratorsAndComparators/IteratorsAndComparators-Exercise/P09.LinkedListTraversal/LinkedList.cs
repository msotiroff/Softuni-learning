namespace P09.LinkedListTraversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }

            public Node Next { get; set; }
        }

        public int Count { get; private set; }

        public Node Head { get; private set; }

        public Node Tail { get; private set; }

        public bool Remove(T item)
        {
            if (this.Count == 0)
            {
                return false;
            }

            var currentItem = this.Head;

            if (currentItem.Value.Equals(item))
            {
                if (this.Count > 1)
                {
                    this.Head = currentItem.Next;
                }

                currentItem = null;

                this.Count--;
                return true;
            }

            while (currentItem.Next != null)
            {
                if (currentItem.Next.Value.Equals(item))
                {
                    var left = currentItem;
                    var right = currentItem.Next?.Next;

                    currentItem = currentItem.Next;
                    currentItem = null;

                    if (right == null)
                    {
                        this.Tail = left;
                        left.Next = null;
                    }
                    else
                    {
                        left.Next = right;
                    }

                    this.Count--;
                    return true;
                }
                else
                {
                    currentItem = currentItem.Next;
                }
            }

            return false;
        }

        public void Add(T item)
        {
            Node oldTail = this.Tail;

            this.Tail = new Node(item);

            if (this.Count == 0)
            {
                this.Head = this.Tail;
            }
            else
            {
                oldTail.Next = this.Tail;
            }

            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.Head;

            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
