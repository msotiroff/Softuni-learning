namespace Stations.Models
{
    using System.Collections.Generic;

    public class Station
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Town { get; set; }

        public ICollection<Trip> TripsTo { get; set; } = new HashSet<Trip>();

        public ICollection<Trip> TripsFrom { get; set; } = new HashSet<Trip>();
    }
}
