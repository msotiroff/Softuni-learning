namespace LoggerSystem.Models.Implementations.Layouts
{
    using Common;
    using Contracts;
    using Dtos;
    using System;
    using System.Globalization;
    using System.Xml.Linq;

    public class XmlLayout : ILayout
    {
        public string FormatError(IError error)
        {
            var dateAsString = error.DateTime
                .ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);

            var level = error.ErrorLevel.ToString();

            var message = error.Message;

            var dto = new ErrorDto(dateAsString, level, message);

            var xmlErrorDoc = new XDocument(new XElement("Log"));

            xmlErrorDoc
                .Root
                .Add(new XElement(nameof(dto.DateTime), dto.DateTime),
                        new XElement(nameof(dto.Level), dto.Level),
                        new XElement(nameof(dto.Message), dto.Message));

            var formattedXmlDoc = xmlErrorDoc.ToString() + Environment.NewLine;

            return formattedXmlDoc;
        }
    }
}
