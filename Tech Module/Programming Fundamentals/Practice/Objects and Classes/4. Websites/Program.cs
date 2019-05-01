using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Websites
{
    public class Websites
    {
       public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();
            List<Website> allWebSites = new List<Website>();

            while (inputLine != "end")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { ' ', ',', '|'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentHost = inputParameters[0];
                string currentDomain = inputParameters[1];
                Website currentWebSite = new Website
                {
                    Host = currentHost,
                    Domain = currentDomain,
                    Queries = new List<string>()
                };
                for (int i = 2; i < inputParameters.Length; i++)
                {
                    string currentQuery = inputParameters[i];
                    currentWebSite.Queries.Add(currentQuery);
                }

                allWebSites.Add(currentWebSite);

                inputLine = Console.ReadLine();
            }

            foreach (var website in allWebSites)
            {
                if (website.Queries.Count > 0)
                {
                    Console.WriteLine($"https://www.{website.Host}.{website.Domain}/query?=[{string.Join("]&[", website.Queries)}]");
                }
                else
                {
                    Console.WriteLine($"https://www.{website.Host}.{website.Domain}");
                }
            }

        }
    }
}
