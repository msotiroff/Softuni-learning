using System.Collections.Generic;

public class PersonEqualityComparer : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        var result = true;

        if (x.Name != y.Name || x.Age != y.Age)
        {
            result = false;
        }

        return result;
    }

    public int GetHashCode(Person obj)
    {
        return 0;
    }
}
