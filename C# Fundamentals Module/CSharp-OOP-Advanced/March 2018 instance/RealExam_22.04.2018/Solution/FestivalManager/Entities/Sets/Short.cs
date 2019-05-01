namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int MaxMinutes = 15;

		public Short(string name) 
			: base(name)
		{
		}

        public override TimeSpan MaxDuration => new TimeSpan(default(int), MaxMinutes, default(int));
    }
}