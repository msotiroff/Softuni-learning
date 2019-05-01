using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class Station
    {
        /*
         Id – integer, Primary Key
        Name – text with max length 50 (required, unique)
        Town – text with max length 50 (required)
        TripsTo – Collection of type Trip
        TripsFrom – Collection of type Trip
         */

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Town { get; set; }

        public ICollection<Trip> TripsTo { get; set; } = new HashSet<Trip>();

        public ICollection<Trip> TripsFrom { get; set; } = new HashSet<Trip>();

    }
}
