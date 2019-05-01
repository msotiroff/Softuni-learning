namespace ExtendedDataBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Database
    {
        private IList<Person> people;

        public Database(params Person[] people)
        {
            this.people = new List<Person>(people);
        }

        public Person this[int index] => this.people[index];

        public int Count => this.people.Count;

        public void Add(Person person)
        {
            var isUsernameОccupied = this.people
                .Any(p => p.Username == person.Username);

            var isIdОccupied = this.people
                .Any(p => p.Id == person.Id);

            if (isUsernameОccupied)
            {
                throw new InvalidOperationException();
            }

            if (isIdОccupied)
            {
                throw new InvalidOperationException();
            }

            this.people.Add(person);
        }

        public void Remove()
        {
            var lastIndex = this.people.Count - 1;

            if (lastIndex < 0)
            {
                throw new InvalidOperationException();
            }

            this.people.RemoveAt(lastIndex);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.people
                .FirstOrDefault(p => p.Id == id) 
                ?? throw new InvalidOperationException();
        }

        public Person FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException();
            }

            return this.people
                .FirstOrDefault(p => p.Username == username)
                ?? throw new InvalidOperationException();
        }
    }
}
