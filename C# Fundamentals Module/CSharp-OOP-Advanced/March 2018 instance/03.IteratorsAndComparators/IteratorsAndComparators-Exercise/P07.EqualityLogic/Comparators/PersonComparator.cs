using System.Collections.Generic;

public class PersonComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.CompareTo(y.Name);
        if (result == 0)
        {
            result = x.Age.CompareTo(y.Age);
        }

        return result;
    }
}
