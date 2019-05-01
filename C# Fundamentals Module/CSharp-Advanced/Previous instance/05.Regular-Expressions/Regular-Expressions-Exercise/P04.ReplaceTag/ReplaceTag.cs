namespace P04.ReplaceTag
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceTag
    {
        public static void Main(string[] args)
        {
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "end")
            {

                var pattern = @"<a href=(?<Link>"".*?"")\>(?<Name>.*?)<\/a>";

                var result = Regex.Replace(inputLine, pattern,
                    r => $@"[URL href={r.Groups["Link"]}]{r.Groups["Name"]}[/URL]");

                Console.WriteLine(result);
            }
        }
    }
}
