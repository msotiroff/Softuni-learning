using System;

namespace FestivalManager.Entities.Instruments
{
	using Contracts;

	public abstract class Instrument : IInstrument
	{
		private double wear;
		private const int MaxWear = 100;
        private const int MinWear = 0;

		protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
                if (value < MinWear)
                {
                    this.wear = MinWear;
                }
                else if (value > MaxWear)
                {
                    this.wear = MaxWear;
                }
                else
                {
                    this.wear = value;
                }
			}
		}

		protected abstract int RepairAmount { get; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= MinWear;

		public override string ToString()
		{
			var instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			var result =  $"{this.GetType().Name} [{instrumentStatus}]";

            return result;
		}
	}
}
