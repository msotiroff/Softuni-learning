using System;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        private const int MaxMinutes = 60;

        public Long(string name) 
            : base(name)
        {
        }

        public override TimeSpan MaxDuration => new TimeSpan(default(int), MaxMinutes, default(int));
    }
}
