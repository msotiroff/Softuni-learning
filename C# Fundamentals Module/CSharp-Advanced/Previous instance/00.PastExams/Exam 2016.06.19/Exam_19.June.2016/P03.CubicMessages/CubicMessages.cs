namespace P03.CubicMessages
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class CubicMessages
    {
        public static void Main(string[] args)
        {
            var allMessages = new Dictionary<string, string>();
            
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Over!")
            {
                int msgLength = int.Parse(Console.ReadLine());
                
                var pattern = $@"^([\d]+)([a-zA-Z]{{{msgLength}}})([^a-zA-Z]*)$";

                var message = Regex.Match(inputLine, pattern);

                if (message.Success)
                {
                    var matches = Regex
                        .Matches(inputLine, @"\d");

                    var indeces = new List<int>();

                    foreach (Match match in matches)
                    {
                        var index = int.Parse(match.ToString());
                        indeces.Add(index);
                    }

                    var msg = message.Groups[2].Value.ToString();

                    var verificationCode = GetVerificationCode(msg, indeces);

                    allMessages.Add(msg, verificationCode);
                }
            }

            foreach (var msg in allMessages)
            {
                Console.WriteLine($"{msg.Key} == {msg.Value}");
            }
        }

        private static string GetVerificationCode(string msg, List<int> indeces)
        {
            var result = new StringBuilder();

            for (int i = 0; i < indeces.Count; i++)
            {
                result.Append((indeces[i] >= 0 && indeces[i] < msg.Length) ? msg[indeces[i]] : ' ');
            }

            return result.ToString();
        }
    }
}
