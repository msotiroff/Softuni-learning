using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.ImportDtos
{
    [XmlType("Ticket")]
    public class TicketDto
    {
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        [XmlAttribute("price")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{2}[0-9]{1,6}$")]
        [XmlAttribute("seat")]
        public string SeatingPlace { get; set; }
        
        [Required]
        [XmlElement("Trip")]
        public TicketTripDto Trip { get; set; }
        
        [XmlElement("Card")]
        public TicketCardDto CustomerCard { get; set; }
    }
}
