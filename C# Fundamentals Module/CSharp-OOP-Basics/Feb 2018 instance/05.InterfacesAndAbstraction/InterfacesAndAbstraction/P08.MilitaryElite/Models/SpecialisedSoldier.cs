namespace P08.MilitaryElite.Models
{
    using Contracts;
    using System;
    using System.Linq;

    public class SpecialisedSoldier : Private, ISpecialisedSoldier, ISoldier
    {
        private readonly string[] ValidCorps = { "Airforces", "Marines" };

        private string corps;

        public string Corps
        {
            get => this.corps;
            private set
            {
                if (!this.ValidCorps.Contains(value))
                {
                    throw new ArgumentException("Invalid Corps!");
                }

                this.corps = value;
            }
        }

        public SpecialisedSoldier(int id, string firstName, string lastName, double salary, string corps) 
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
        }
    }
}
