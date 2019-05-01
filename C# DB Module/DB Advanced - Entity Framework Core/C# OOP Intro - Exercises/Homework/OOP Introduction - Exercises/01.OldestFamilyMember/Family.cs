using System.Collections.Generic;
using System.Linq;

public class Family
{
    private List<Person> people;

    public Family()
    {
        this.People = new List<Person>();
    }

    public List<Person> People
    {
        get { return this.people; }
        private set
        {
            this.people = value;
        }
    }

    public void AddMember(Person member)
    {
        this.people.Add(member);
    }

    public Person GetOldestMember()
    {
        var oldestMember = this.people
            .Where(p => p.Age == this.people.Max(x => x.Age))
            .First();

        return oldestMember;
    }

    public string PrintOldestMember()
    {
        return $"{this.GetOldestMember().Name} {this.GetOldestMember().Age}";
    }
}