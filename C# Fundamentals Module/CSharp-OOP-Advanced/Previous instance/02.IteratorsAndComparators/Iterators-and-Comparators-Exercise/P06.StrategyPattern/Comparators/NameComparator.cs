using System.Collections.Generic;

public class NameComparator : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name.Length < y.Name.Length)
        {
            return -1;
        }
        else if (x.Name.Length > y.Name.Length)
        {
            return 1;
        }

        return x.Name.ToLower().CompareTo(y.Name.ToLower());
    }
}
