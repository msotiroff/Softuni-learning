using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Srbsko_Unleashed
{
    class SrbskoUnleashed
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> srbsko =
                new Dictionary<string, Dictionary<string, int>>();

            string inputLine = Console.ReadLine();

            //  Lepa Brena @Sunny Beach 25 3500

            while (inputLine != "End")
            {
                string[] inputParameters = inputLine.Split('@').ToArray();

                string currentSinger = inputParameters[0];
                if (currentSinger.Last() != ' ')
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                currentSinger = inputParameters[0].TrimEnd();

                string venuePriceCountPair = inputParameters[1];

                List<string> venueAndOtherParameters = venuePriceCountPair.Split(' ').ToList();

                int currentTicketsCount;
                int currentTicketPrice;
                if (int.TryParse(venueAndOtherParameters[venueAndOtherParameters.Count - 1], out currentTicketsCount))
                {
                    if (int.TryParse(venueAndOtherParameters[venueAndOtherParameters.Count - 2], out currentTicketPrice))
                    {
                        venueAndOtherParameters.RemoveAt(venueAndOtherParameters.Count - 1);
                        venueAndOtherParameters.RemoveAt(venueAndOtherParameters.Count - 1);

                        string currentPlace = string.Join(" ", venueAndOtherParameters);
                        int currentIncomeMoney = currentTicketPrice * currentTicketsCount;

                        if (!srbsko.ContainsKey(currentPlace))
                        {
                            srbsko[currentPlace] = new Dictionary<string, int>();
                        }
                        if (!srbsko[currentPlace].ContainsKey(currentSinger))
                        {
                            srbsko[currentPlace][currentSinger] = 0;
                        }

                        srbsko[currentPlace][currentSinger] += currentIncomeMoney;
                    }
                }


                inputLine = Console.ReadLine();
            }

            foreach (var place in srbsko)
            {
                Console.WriteLine(place.Key);

                foreach (var singer in place.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }

        }
    }
}
