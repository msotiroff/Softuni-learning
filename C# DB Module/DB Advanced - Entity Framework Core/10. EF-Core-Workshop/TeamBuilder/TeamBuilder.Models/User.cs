namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        private string password;

        public string Password
        {
            get { return this.password; }
            set
            {
                if (!value.Any(v => char.IsDigit(v)))
                {
                    throw new ArgumentException("Password must contain at least one digit");
                }
                if (!value.Any(v => char.IsUpper(v)))
                {
                    throw new ArgumentException("Password must contain at least one uppercase letter");
                }

                this.password = value;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Team> CreatedTeams { get; set; } = new HashSet<Team>();

        public ICollection<Event> CreatedEvents { get; set; } = new HashSet<Event>();

        public ICollection<Invitation> RecievedInvitations { get; set; } = new HashSet<Invitation>();

        public ICollection<UserTeam> UserTeams { get; set; } = new HashSet<UserTeam>();
    }
}
