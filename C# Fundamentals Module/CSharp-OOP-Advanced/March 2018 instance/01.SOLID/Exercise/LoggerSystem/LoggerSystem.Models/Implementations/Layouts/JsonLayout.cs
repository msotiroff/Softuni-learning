namespace LoggerSystem.Models.Implementations.Layouts
{
    using Common;
    using Contracts;
    using Dtos;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    public class JsonLayout : ILayout
    {
        public string FormatError(IError error)
        {
            var dateAsString = error.DateTime
                .ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);

            var level = error.ErrorLevel.ToString();

            var message = error.Message;

            var dto = new ErrorDto(dateAsString, level, message);

            var formattedError = JsonConvert
                .SerializeObject(dto, Formatting.Indented) 
                + Environment.NewLine;

            return formattedError;
        }
    }
}
