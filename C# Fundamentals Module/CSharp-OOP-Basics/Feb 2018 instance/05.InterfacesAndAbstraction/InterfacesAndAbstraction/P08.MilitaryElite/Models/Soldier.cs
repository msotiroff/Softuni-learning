﻿namespace P08.MilitaryElite.Models
{
    using Contracts;

    public class Soldier : ISoldier
    {
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Soldier (int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
