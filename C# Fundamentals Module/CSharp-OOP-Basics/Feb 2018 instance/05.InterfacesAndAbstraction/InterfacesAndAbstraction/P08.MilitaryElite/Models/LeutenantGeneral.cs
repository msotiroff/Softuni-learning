namespace P08.MilitaryElite.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    public class LeutenantGeneral : Private, ILeutenantGeneral, ISoldier
    {

        public List<IPrivate> Privates { get; private set; }

        public LeutenantGeneral(int id, string firstName, string lastName, double salary, List<IPrivate> privates) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }

        public override string ToString()
        {
            var builder = new StringBuilder()
                .AppendLine(base.ToString())
                .AppendLine("Privates:");

            foreach (var @private in this.Privates.OrderBy(p => p.Id))
            {
                builder.AppendLine($"  {@private.ToString()}");
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }
    }
}
