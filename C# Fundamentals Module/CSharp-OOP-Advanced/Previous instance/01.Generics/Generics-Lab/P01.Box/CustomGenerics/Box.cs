using System.Collections.Generic;
using System.Linq;

public class Box<T>
{

    private IList<T> elements;

    public int Count => this.elements.Count;

    public Box()
    {
        this.elements = new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }

    public T Remove()
    {
        if (this.Count > 0)
        {
            var lastElement = this.elements.Last();
            this.elements.RemoveAt(this.Count - 1);
            return lastElement;
        }

        throw new System.ArgumentException("No elements to be removed!");
    }

}