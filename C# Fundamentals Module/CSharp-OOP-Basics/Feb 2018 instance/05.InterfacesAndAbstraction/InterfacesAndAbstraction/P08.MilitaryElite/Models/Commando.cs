namespace P08.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Text;
    using Contracts;

    public class Commando : SpecialisedSoldier, ICommando, ISoldier
    {
        public List<IMission> Missions { get; private set; }

        public Commando(int id, string firstName, string lastName, double salary, string corps, List<IMission> missions) 
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

        public override string ToString()
        {
            var builder = new StringBuilder()
                .AppendLine(base.ToString())
                .AppendLine($"Corps: {this.Corps}")
                .AppendLine("Missions:");

            foreach (var mission in this.Missions)
            {
                builder.AppendLine(mission.ToString());
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }
    }
}
