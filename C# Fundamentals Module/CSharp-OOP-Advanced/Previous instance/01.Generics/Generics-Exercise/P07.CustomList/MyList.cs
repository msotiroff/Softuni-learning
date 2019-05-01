using System;
using System.Collections.Generic;
using System.Linq;

public class MyList<T> : List<T> 
    where T : IComparable<T>
{
    public void Swap(int index1, int index2)
    {
        var firstElement = this[index1];

        this[index1] = this[index2];
        this[index2] = firstElement;
    }

    public T Remove(int index)
    {
        var element = this[index];
        this.RemoveAt(index);

        return element;
    }

    public int CountGreaterThan(T element)
    {
        return this.Count(e => element.CompareTo(e) < 0);
    }



    public override string ToString()
    {
        return string.Join(Environment.NewLine, this);
    }
}