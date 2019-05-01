namespace Stations.Models
{
    using System.Collections.Generic;

    public class CustomerCard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public CardType Type { get; set; } = CardType.Normal;

        public ICollection<Ticket> BoughtTickets { get; set; } = new HashSet<Ticket>();
    }
}