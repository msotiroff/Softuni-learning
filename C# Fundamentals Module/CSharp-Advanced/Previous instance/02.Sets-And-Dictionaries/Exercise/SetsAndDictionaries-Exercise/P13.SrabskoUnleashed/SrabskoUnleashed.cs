namespace P13.SrabskoUnleashed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class SrabskoUnleashed
    {
        public static void Main(string[] args)
        {
            //  <Venue, <Singer, Total Money>>
            var concerts = new Dictionary<string, Dictionary<string, int>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "End")
            {
                var pattern = @"^(?<Singer>.+)\s@(?<Venue>.+)\s(?<Price>\d+)\s(?<Count>\d+)$";
                var splitter = new Regex(pattern);

                if (!splitter.IsMatch(inputLine))
                {
                    continue;
                }

                var match = splitter.Match(inputLine);

                var singer = match.Groups["Singer"].Value.ToString();
                var venue = match.Groups["Venue"].Value.ToString();

                var ticketPrice = int.Parse(match.Groups["Price"].Value.ToString());
                var ticketCount = int.Parse(match.Groups["Count"].Value.ToString());

                var moneyByTickets = ticketPrice * ticketCount;

                if (!concerts.ContainsKey(venue))
                {
                    concerts[venue] = new Dictionary<string, int>();
                }

                if (!concerts[venue].ContainsKey(singer))
                {
                    concerts[venue][singer] = 0;
                }

                concerts[venue][singer] += moneyByTickets;
            }

            foreach (var venue in concerts)
            {
                Console.WriteLine(venue.Key);

                foreach (var singer in venue.Value.OrderByDescending(s => s.Value))
                {
                    var singerName = singer.Key;
                    var moneyEarned = singer.Value;
                    Console.WriteLine($"#  {singerName} -> {moneyEarned}");
                }
            }
        }
    }
}
