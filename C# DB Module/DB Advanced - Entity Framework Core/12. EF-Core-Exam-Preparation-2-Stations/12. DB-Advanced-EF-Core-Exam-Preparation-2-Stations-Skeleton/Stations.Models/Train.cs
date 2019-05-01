namespace Stations.Models
{
    using System.Collections.Generic;

    public class Train
    {
        public int Id { get; set; }

        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } = new HashSet<TrainSeat>();

        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
