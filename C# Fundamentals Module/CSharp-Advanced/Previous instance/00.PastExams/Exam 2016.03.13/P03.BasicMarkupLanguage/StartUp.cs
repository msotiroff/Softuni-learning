namespace P03.BasicMarkupLanguage
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var result = new StringBuilder();

            var pattern = @"\s*<\s*([a-z]+)\s+(?:value\s*=\s*""\s*(\d+)\s*""\s+)?[a-z]+\s*=\s*""([^""]*)""\s*\/>\s*";

            var rowCounter = 0;

            string currentRow;
            while ((currentRow = Console.ReadLine()) != "<stop/>")
            {
                var match = Regex.Match(currentRow, pattern);

                if (match.Success)
                {
                    var command = match.Groups[1].Value;
                    var value = match.Groups[2].Value.ToString();
                    var content = match.Groups[3].Value;

                    if (content.Length > 0)
                    {
                        switch (command)
                        {
                            case "inverse":
                                result.AppendLine($"{++rowCounter}. {InverseContent(content)}");
                                break;
                            case "reverse":
                                result.AppendLine($"{++rowCounter}. {ReverseContent(content)}");
                                break;
                            case "repeat":
                                for (int i = 0; i < int.Parse(value); i++)
                                {
                                    result.AppendLine($"{++rowCounter}. {content}");
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            Console.Write(result);
        }

        private static string ReverseContent(string content)
        {
            var result = new StringBuilder();

            for (int index = content.Length - 1; index >= 0; index--)
            {
                result.Append(content[index]);
            }

            return result.ToString();
        }

        private static string InverseContent(string content)
        {
            var result = new StringBuilder();

            for (int index = 0; index < content.Length; index++)
            {
                if (char.IsUpper(content[index]))
                {
                    result.Append(content[index].ToString().ToLower());
                }
                else if (char.IsLower(content[index]))
                {
                    result.Append(content[index].ToString().ToUpper());
                }
                else
                {
                    result.Append(content[index]);
                }
            }

            return result.ToString();
        }
    }
}
