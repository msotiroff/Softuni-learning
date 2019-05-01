namespace LoggerSystem.Models.Dtos
{
    using Implementations.Errors;
    using System.Xml.Serialization;

    [XmlType(nameof(Error))]
    public class ErrorDto
    {
        public ErrorDto(string datetime, string level, string message)
        {
            this.DateTime = datetime;
            this.Level = level;
            this.Message = message;
        }

        [XmlElement(nameof(Error.DateTime))]
        public string DateTime { get; set; }

        [XmlElement(nameof(Error.ErrorLevel))]
        public string Level { get; set; }

        [XmlElement(nameof(Error.Message))]
        public string Message { get; set; }
    }
}
