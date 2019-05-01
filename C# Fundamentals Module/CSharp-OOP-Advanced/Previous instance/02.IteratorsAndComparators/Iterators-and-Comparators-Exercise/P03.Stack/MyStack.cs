using System;
using System.Collections;
using System.Collections.Generic;

public class MyStack<T> : IEnumerable<T>
{
    private List<T> data;

    public MyStack()
    {
        this.data = new List<T>();
    }

    public void Push(params T[] elements)
    {
        foreach (var element in elements)
        {
            this.data.Add(element);
        }
    }

    public T Pop()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var lastIndex = this.data.Count - 1;
        var lastElement = this.data[lastIndex];

        this.data.RemoveAt(lastIndex);

        return lastElement;
    }

    public T Peek()
    {
        if (this.data.Count == 0)
        {
            throw new InvalidOperationException("Sequence is empty");
        }

        var lastIndex = this.data.Count - 1;
        var lastElement = this.data[lastIndex];

        return lastElement;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.data.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
