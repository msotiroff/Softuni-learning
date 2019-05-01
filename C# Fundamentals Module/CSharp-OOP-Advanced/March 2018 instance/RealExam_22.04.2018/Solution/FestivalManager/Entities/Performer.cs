namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Performer : IPerformer
	{
        private const string PerformerFormat = "---{0} ({1})";

		private List<IInstrument> instruments;

		public Performer(string name, int age)
		{
			this.Name = name;
			this.Age = age;

			this.instruments = new List<IInstrument>();
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => this.instruments.AsReadOnly();

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
            var instrumentsOrdered = this.Instruments.OrderByDescending(i => i.Wear).ToList();

            var instrumentsInfo = string.Join(", ", instrumentsOrdered.Select(i => i.ToString()));

            var result = string.Format(PerformerFormat, this.Name, instrumentsInfo);

            return result;
		}
	}
}
