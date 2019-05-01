using System;
using System.Collections.Generic;
using System.Linq;

public class Box<T> 
    where T : IComparable<T>
{
    private IEnumerable<T> values;

    public Box(IEnumerable<T> values)
    {
        this.values = values;
    }
    
    public int CountOfGreaterElements(T element) => 
        this.values
        .Count(e => element.CompareTo(e) < 0);
}