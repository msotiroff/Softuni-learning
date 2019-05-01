namespace P11.SemanticHTML
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SemanticHTML
    {
        public static void Main(string[] args)
        {
            var result = new StringBuilder();

            var openTagPattern = @"<div(?<attribute1>[^>]*)(id|class)\s*=\s*""(?<tag>[A-Za-z]+)""(?<attribute2>[^>]*)>";
            var closeTagPattern = @"<\/div>\s*<!--\s*(?<tag>[A-Za-z]+)\s*-->";

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var openTag = Regex.Match(inputLine, openTagPattern);
                var closeTag = Regex.Match(inputLine, closeTagPattern);

                if (openTag.Success)
                {

                    string tagWithAttributes =
                        Regex.Replace(inputLine, openTagPattern, x => $"{x.Groups["tag"]} {x.Groups["attribute1"]} {x.Groups["attribute2"]}").Trim();
                    tagWithAttributes = Regex.Replace(tagWithAttributes, "\\s+", " ");

                    string newTag = $"<{tagWithAttributes}>";

                    result.AppendLine(newTag);
                }
                else if (closeTag.Success)
                {
                    string tag = closeTag.Groups["tag"].Value.ToString();
                    string newTag = $"</{tag}>";

                    result.AppendLine(newTag);
                }
                else
                {
                    result.AppendLine(inputLine);
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
