using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Person
{
    public string Name { get; set; }

    public Company Company { get; set; }

    public Car Car { get; set; }

    public string BirthDay { get; set; }

    public IList<Pokemon> Pokemons { get; set; }

    public IList<Person> Parents { get; set; }

    public IList<Person> Children { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public Person(string name, string birthday)
        : this(name)
    {
        this.BirthDay = birthday;
    }

    public override string ToString()
    {
        var result = new StringBuilder()
            .AppendLine(this.Name)
            .AppendLine($"Company:");
        if (this.Company != null)
        {
            result.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:f2}");
        }
        result.AppendLine("Car:");
        if (this.Car != null)
        {
            result.AppendLine($"{this.Car.Model} {this.Car.Speed}");
        }
        result.AppendLine("Pokemon:");
        if (this.Pokemons.Any())
        {
            foreach (var pokemon in this.Pokemons)
            {
                result.AppendLine($"{pokemon.Name} {pokemon.Type}");
            }
        }
        result.AppendLine("Parents:");
        if (this.Parents.Any())
        {
            foreach (var parent in this.Parents)
            {
                result.AppendLine($"{parent.Name} {parent.BirthDay}");
            }
        }
        result.AppendLine("Children:");
        if (this.Parents.Any())
        {
            foreach (var child in this.Children)
            {
                result.AppendLine($"{child.Name} {child.BirthDay}");
            }
        }

        return result.ToString().TrimEnd();
    }
}