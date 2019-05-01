using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.CottageScraper
{
    public class CottageScraper
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<int>> logging = new Dictionary<string, List<int>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "chop chop")
            {
                string[] tokens = inputLine
                    .Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string treeType = tokens[0];
                int treeLenght = int.Parse(tokens[1]);

                if (! logging.ContainsKey(treeType))
                {
                    logging[treeType] = new List<int>();
                }
                logging[treeType].Add(treeLenght);
                

                inputLine = Console.ReadLine();
            }

            string neededTreeType = Console.ReadLine();
            int neededMinLenght = int.Parse(Console.ReadLine());
            
            List<int> neededTrees = logging[neededTreeType].Where(x => x >= neededMinLenght).ToList();

            int allTreeLenght = 0;
            int countOfTrees = 0;
            foreach (var item in logging)
            {
                var currentListInt = item.Value;
                foreach (var lenghts in currentListInt)
                {
                    allTreeLenght += lenghts;
                    countOfTrees++;
                }
            }

            double pricePerMeter = Math.Round((double)allTreeLenght / countOfTrees, 2);

            int allUsedLenght = neededTrees.Sum();

            double usedLogsPrice = Math.Round(pricePerMeter * allUsedLenght, 2);

            int notUsedTreesLenght = allTreeLenght - allUsedLenght;


            double unUsedLogsPrice = Math.Round(pricePerMeter * notUsedTreesLenght * 0.25, 2);

            double cottageSubTotal = usedLogsPrice + unUsedLogsPrice;

            Console.WriteLine($"Price per meter: ${pricePerMeter:f2}");
            Console.WriteLine($"Used logs price: ${usedLogsPrice:f2}");
            Console.WriteLine($"Unused logs price: ${unUsedLogsPrice:f2}");
            Console.WriteLine($"CottageScraper subtotal: ${cottageSubTotal:f2}");
        }
    }
}
