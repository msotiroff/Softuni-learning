using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.EmailStatistics
{
    class EmailStatistics
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> allMailData = new Dictionary<string, List<string>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            Regex validateEmail = new Regex(@"^([A-Za-z]{5,})@([a-z]{3,}(\.com|\.bg|\.org){1})$");

            for (int i = 0; i < numberOfInputs; i++)
            {
                string currentEmail = Console.ReadLine();

                var matchedEmail = validateEmail.Match(currentEmail);

                if (matchedEmail.Success)
                {
                    string currentUserName = matchedEmail.Groups[1].Value.ToString();
                    string currentDomain = matchedEmail.Groups[2].Value.ToString();

                    if (! allMailData.ContainsKey(currentDomain))
                    {
                        allMailData[currentDomain] = new List<string>();
                    }
                    if (! allMailData[currentDomain].Contains(currentUserName))
                    {
                        allMailData[currentDomain].Add(currentUserName);
                    }                    
                }
            }


            foreach (var domain in allMailData.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{domain.Key}:");
                foreach (var user in domain.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}
