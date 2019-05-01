using System;
using System.Collections.Generic;
using System.Text;

namespace Stations.DataProcessor.Dto
{
    public class TicketForImportDto
    {
        public decimal Price { get; set; }

        public string SeatingPlace { get; set; }

        public int TripId { get; set; }
    }
}
