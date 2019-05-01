using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.DataProcessor.Dto.ImportDtos
{
    public class TripDto
    {
        [Required]
        public string Train { get; set; }

        [Required]
        public string OriginStation { get; set; }
        
        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }

        public string Status { get; set; }

        public string TimeDifference { get; set; }
    }
}
