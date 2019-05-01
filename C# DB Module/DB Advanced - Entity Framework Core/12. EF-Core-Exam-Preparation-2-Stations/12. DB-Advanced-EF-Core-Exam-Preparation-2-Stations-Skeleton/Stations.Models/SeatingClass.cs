using System.Collections.Generic;

namespace Stations.Models
{
    public class SeatingClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }
        
        public ICollection<TrainSeat> TrainSeats { get; set; } = new HashSet<TrainSeat>();
    }
}
