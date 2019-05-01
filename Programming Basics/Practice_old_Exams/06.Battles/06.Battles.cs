using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokemonsFirstGamer = int.Parse(Console.ReadLine());
            int pokemonsSecondGamer = int.Parse(Console.ReadLine());
            int maxBattles = int.Parse(Console.ReadLine());
            int battleCounter = 0;
            for (int i = 1; i <= pokemonsFirstGamer; i++)
            {
                for (int j = 1; j <= pokemonsSecondGamer; j++)
                {
                    Console.Write($"({i} <-> {j}) ");
                    battleCounter++;
                    if (battleCounter == maxBattles)
                    {
                        return;
                    }
                }
            }
        }
    }
}
