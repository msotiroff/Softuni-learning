namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        private DateTime? endDate;

        public DateTime? EndDate
        {
            get { return this.endDate; }
            set
            {
                if (value <= this.StartDate)
                {
                    throw new ArgumentException("End date must be after Start date!");
                }

                this.endDate = value;
            }
        }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<TeamEvent> ParticipatingTeamEvents { get; set; } = new HashSet<TeamEvent>();
    }
}
