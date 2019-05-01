using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Shellbound
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<int>> shellsPerRegion = new Dictionary<string, HashSet<int>>();

            string[] input = Console.ReadLine().Split(' ').ToArray();

            while (input[0] != "Aggregate")
            {
                string region = input[0];
                int shell = int.Parse(input[1]);

                if (!shellsPerRegion.ContainsKey(region))
                {
                    shellsPerRegion[region] = new HashSet<int>();
                }
                shellsPerRegion[region].Add(shell);

                input = Console.ReadLine().Split(' ').ToArray();
            }

            foreach (var kvp in shellsPerRegion)
            {
                int sum = kvp.Value.Sum();
                int countOfShells = kvp.Value.Count();
                int giantShell = sum - sum / countOfShells;

                Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)} ({giantShell})");
            }

        }
    }
}
