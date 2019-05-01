using System.Collections.Generic;

namespace Stations.Models
{
    public class TrainSeat
    {
        public int Id { get; set; }

        public int TrainId { get; set; }
        public Train Train { get; set; }

        public int SeatingClassId { get; set; }
        public SeatingClass SeatingClass { get; set; }

        public int Quantity { get; set; }
    }
}
