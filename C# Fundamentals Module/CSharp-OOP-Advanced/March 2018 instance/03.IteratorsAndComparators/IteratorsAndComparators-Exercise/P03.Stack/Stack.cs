using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Stack<T> : IEnumerable<T>
{
    private const string StackEmpty = "No elements";

    private List<T> items;

    public Stack()
    {
        this.items = new List<T>();
    }

    public Stack(IEnumerable<T> items)
        : this()
    {
        this.items.AddRange(items);
    }

    public void Push(T[] items)
    {
        this.items.AddRange(items);
    }

    public T Pop()
    {
        var item = this.items.LastOrDefault();

        if (item == null)
        {
            throw new InvalidOperationException(StackEmpty);
        }

        this.items.RemoveAt(this.items.Count - 1);

        return item;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.items.Count - 1; i >= 0; i--)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
