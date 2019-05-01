using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> members;

    public Family()
    {
        this.members = new List<Person>();
    }

    public IEnumerable<Person> Members
    {
        get => this.members;
    }

    public void AddMember (Person member)
    {
        this.members.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.members
            .OrderByDescending(p => p.Age)
            .FirstOrDefault();
    }
}
