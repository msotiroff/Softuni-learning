namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
        private const int MaxMinutes = 40;

        public Medium(string name)
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => new TimeSpan(default(int), MaxMinutes, default(int));
    }
}