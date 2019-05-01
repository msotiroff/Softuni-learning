using System;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> where T : IComparable<T>
{
    private IList<T> elements;
    
    public CustomList()
    {
        this.Elements = new List<T>();
    }

    public CustomList(IList<T> collection)
        : this()
    {
        this.Elements = collection;
    }

    public IList<T> Elements
    {
        get => elements;
        private set => elements = value;
    }

    public void Add(T element) => this.Elements.Add(element);

    public T Remove(int index)
    {
        var element = this.Elements[index];

        this.Elements.RemoveAt(index);

        return element;
    }
    public bool Contains(T element) => this.Elements.Contains(element);

    public void Swap(int index1, int index2)
    {
        var firstElement = this.Elements[index1];
        this.Elements[index1] = this.Elements[index2];
        this.Elements[index2] = firstElement;
    }

    public int CountGreaterThan(T element) 
        => this.Elements.Count(e => e.CompareTo(element) > 0);

    public T Max() => this.Elements.Max();

    public T Min() => this.Elements.Min();
    
    public override string ToString() => string.Join(Environment.NewLine, this.Elements);
}
