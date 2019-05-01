namespace TeamBuilder.Models
{
    using System.Collections.Generic;

    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public ICollection<UserTeam> UserTeams { get; set; } = new HashSet<UserTeam>();

        public ICollection<TeamEvent> TeamEvents { get; set; } = new HashSet<TeamEvent>();
    }
}
