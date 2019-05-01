namespace P07_FamilyTree
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        public string Name { get; set; }

        public string BirthDate { get; set; }

        public IList<Person> Children { get; private set; }

        public IList<Person> Parents { get; private set; }

        public Person(string name, string birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
            this.Children = new List<Person>();
            this.Parents = new List<Person>();
        }

        public void AddParent(Person parent)
        {
            this.Parents.Add(parent);
        }

        public void AddChild(Person child)
        {
            this.Children.Add(child);
        }

        public override string ToString()
        {
            var result = new StringBuilder()
                .AppendLine($"{this.Name} {this.BirthDate}")
                .AppendLine("Parents:");
            if (this.Parents.Any())
            {
                this.Parents
                    .ToList()
                    .ForEach(p => result.AppendLine($"{p.Name} {p.BirthDate}"));
            }
            result.AppendLine("Children:");
            if (this.Children.Any())
            {
                this.Children
                    .ToList()
                    .ForEach(c => result.AppendLine($"{c.Name} {c.BirthDate}"));
            }

            return result.ToString().TrimEnd();
        }
    }
}