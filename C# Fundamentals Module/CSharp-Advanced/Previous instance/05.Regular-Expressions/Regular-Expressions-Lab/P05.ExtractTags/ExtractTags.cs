namespace P05.ExtractTags
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ExtractTags
    {
        public static void Main(string[] args)
        {
            var builder = new StringBuilder();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                builder.Append(inputLine);
            }

            var regex = new Regex(@"<.+?>");

            var tags = regex.Matches(builder.ToString());

            foreach (Match tag in tags)
            {
                Console.WriteLine(tag);
            }
        }
    }
}
