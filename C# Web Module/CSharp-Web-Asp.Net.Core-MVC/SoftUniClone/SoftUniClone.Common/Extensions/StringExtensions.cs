namespace SoftUniClone.Common.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        private const int MaxLength = 250;

        public static string ToFriendlyUrl(this string text)
        {
            return Regex.Replace(text, @"[^A-Za-z0-9_\.~]+", "-");
        }

        public static string ToResume(this string text)
        {
            if (string.IsNullOrEmpty(text) || text.Length < MaxLength)
            {
                return text;
            }

            int symbols = text.IndexOf('.', MaxLength);

            return text.Substring(0, symbols) + " ";
        }
    }
}