namespace Stations.DataProcessor.Dto
{
    using Stations.Models;
    using System;

    public class TripForImportDto
    {
        public string Train { get; set; }

        public string OriginStation { get; set; }
        
        public string DestinationStation { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }
        
        public string Status { get; set; }

        public string TimeDifference { get; set; }
    }
}
