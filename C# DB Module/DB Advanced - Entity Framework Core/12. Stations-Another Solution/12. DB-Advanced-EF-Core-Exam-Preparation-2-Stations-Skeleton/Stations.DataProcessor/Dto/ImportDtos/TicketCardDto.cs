using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.ImportDtos
{
    [XmlType("Card")]
    public class TicketCardDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}