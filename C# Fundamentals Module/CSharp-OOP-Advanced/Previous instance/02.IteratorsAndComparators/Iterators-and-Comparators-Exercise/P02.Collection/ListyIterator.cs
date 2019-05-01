﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T> : IEnumerable<T>
{
    private const string InvalidOperation = "Invalid Operation!";

    private List<T> data;
    private int currentIndex;

    public ListyIterator()
    {
        this.data = new List<T>();
    }
    
    public void Create(params T[] collection)
    {
        this.data.AddRange(collection);
    }

    public bool Move()
    {
        if (this.data.Any() && this.HasNext())
        {
            this.currentIndex++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        if (this.currentIndex < this.data.Count - 1)
        {
            return true;
        }

        return false;
    }

    public string Print()
    {
        if (this.data.Any())
        {
            return this.data[this.currentIndex].ToString();
        }
        else
        {
            return InvalidOperation;
        }
    }

    public string PrintAll()
    {
        return string.Join(" ", this.data);
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.data)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
