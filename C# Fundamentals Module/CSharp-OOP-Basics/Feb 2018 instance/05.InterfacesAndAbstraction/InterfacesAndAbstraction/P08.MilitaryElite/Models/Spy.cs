namespace P08.MilitaryElite.Models
{
    using Contracts;
    using System;

    public class Spy : Soldier, ISpy, ISoldier
    {
        public int CodeNumber { get; private set; }

        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}{Environment.NewLine}"
                + $"Code Number: {this.CodeNumber}";

        }
    }
}
