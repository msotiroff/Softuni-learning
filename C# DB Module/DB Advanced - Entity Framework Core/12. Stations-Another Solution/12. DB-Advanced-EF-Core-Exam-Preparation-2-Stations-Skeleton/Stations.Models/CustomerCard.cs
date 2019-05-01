using Stations.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class CustomerCard
    {
        /*
        Id – integer, Primary Key
        Name – text with max length 128 (required)
        Age – integer between 0 and 120
        Type – CardType enumeration with values: "Pupil", "Student", "Elder", "Debilitated", "Normal" (default: Normal)
        BoughtTickets – Collection of type Ticket
         */

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public CardType Type { get; set; } = CardType.Normal;

        public ICollection<Ticket> BoughtTickets { get; set; } = new HashSet<Ticket>();
    }
}