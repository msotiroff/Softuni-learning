using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public Team(string name)
    {
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    public IList<Person> ReserveTeam
    {
        get { return this.reserveTeam.AsReadOnly(); }
    }


    public IList<Person> FirstTeam
    {
        get { return this.firstTeam.AsReadOnly(); }
    }


    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }


    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

}
