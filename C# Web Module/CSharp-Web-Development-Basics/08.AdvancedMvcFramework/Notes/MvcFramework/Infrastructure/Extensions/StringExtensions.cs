namespace MvcFramework.Infrastructure.Extensions
{
    using System.Globalization;

    public static class StringExtensions
    {
        public static string ToTitleCase(this string input)
        {
            if (input == null || input.Length == 0)
            {
                return input;
            }

            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(input.ToLower()); ;
        }
    }
}
