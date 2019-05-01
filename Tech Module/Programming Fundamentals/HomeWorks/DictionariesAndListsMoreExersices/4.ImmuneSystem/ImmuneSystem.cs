using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.ImmuneSystem
{
    class ImmuneSystem
    {
        static void Main(string[] args)
        {
            int initialHealth = int.Parse(Console.ReadLine());

            int currentHealth = initialHealth;

            List<string> defeatedViruses = new List<string>();

            string virusName = Console.ReadLine();

            while (virusName != "end")
            {
                int virusStrength = 0;
                for (int i = 0; i < virusName.Length; i++)
                {
                    int currentNumToAdd = Convert.ToInt32(virusName[i]);
                    virusStrength += currentNumToAdd;
                }
                virusStrength = (int)(virusStrength / 3);
                
                int virusDefeatSeconds = virusStrength * virusName.Length;

                if (defeatedViruses.Contains(virusName))
                {
                    virusDefeatSeconds /= 3;
                }
                
                int defeatMins = virusDefeatSeconds / 60;
                int defeatSecs = virusDefeatSeconds % 60;

                Console.WriteLine($"Virus {virusName}: {virusStrength} => {virusDefeatSeconds} seconds");

                if (currentHealth > virusDefeatSeconds)
                {
                    Console.WriteLine($"{virusName} defeated in {defeatMins}m {defeatSecs}s.");
                    currentHealth -= virusDefeatSeconds;
                }
                else
                {
                    Console.WriteLine($"Immune System Defeated.");
                    return;
                }
                
                Console.WriteLine($"Remaining health: {currentHealth}");

                currentHealth = Math.Min(initialHealth, (int)(currentHealth * 1.2));

                defeatedViruses.Add(virusName);

                virusName = Console.ReadLine();
            }

            if (currentHealth > 0)
            {
                Console.WriteLine($"Final Health: {currentHealth}");
            }
        }
    }
}
