﻿namespace Instagraph.DataProcessor.Dto.Import
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("post")]
    public class PostDto
    {
        [Required]
        [XmlElement("caption")]
        public string Caption { get; set; }
        
        [Required]
        [XmlElement("user")]
        public string User { get; set; }
        
        [Required]
        [XmlElement("picture")]
        public string Picture { get; set; }
    }
}
