namespace P08.MilitaryElite.Models
{
    using Contracts;

    public class Private : Soldier, IPrivate, ISoldier
    {
        public double Salary { get; private set; }

        public Private(int id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
