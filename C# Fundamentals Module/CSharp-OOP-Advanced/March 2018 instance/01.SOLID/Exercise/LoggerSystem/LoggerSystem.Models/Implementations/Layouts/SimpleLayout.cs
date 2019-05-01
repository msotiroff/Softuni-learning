namespace LoggerSystem.Models.Implementations.Layouts
{
    using Common;
    using Contracts;
    using System.Globalization;

    public class SimpleLayout : ILayout
    {
        public string FormatError(IError error)
        {
            var dateAsString = error.DateTime
                .ToString(Constants.DateTimeFormat, CultureInfo.InvariantCulture);

            var formattedError = string.Format(Constants.SimpleLayoutFormat, dateAsString, error.ErrorLevel, error.Message);

            return formattedError;
        }
    }
}
