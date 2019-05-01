using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.ImportDtos
{
    [XmlType("Trip")]
    public class TicketTripDto
    {
        [Required]
        [XmlElement("OriginStation")]
        public string OriginStation { get; set; }
        
        [Required]
        [XmlElement("DestinationStation")]
        public string DestinationStation { get; set; }

        [Required]
        [XmlElement("DepartureTime")]
        public string DepartureTime { get; set; }
    }
}
