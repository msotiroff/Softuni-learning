using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrderDto
    {
        [Required]
        [XmlElement("Customer")]
        public string Customer { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [Required]
        [XmlElement("Type")]
        public string Type { get; set; } = "ForHere";
        
        [Required]
        [XmlElement("Employee")]
        public string Employee { get; set; }

        [XmlArray("Items")]
        public ItemInOrderDto[] Items { get; set; } = new ItemInOrderDto[0];
    }
}
