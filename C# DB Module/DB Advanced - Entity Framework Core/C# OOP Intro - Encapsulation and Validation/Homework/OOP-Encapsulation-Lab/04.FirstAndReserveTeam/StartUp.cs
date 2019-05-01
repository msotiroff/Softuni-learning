using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FirstAndReserveTeam
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());

            Team newTeam = new Team("CSKA");

            for (int i = 0; i < inputCount; i++)
            {
                string[] inputParams = Console.ReadLine().Split();

                try
                {
                    Person currPerson = new Person(inputParams[0],
                                                   inputParams[1],
                                                   int.Parse(inputParams[2]),
                                                   double.Parse(inputParams[3]));

                    newTeam.AddPlayer(currPerson);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine($"First team have {newTeam.FirstTeam.Count} players");
            Console.WriteLine($"Reserve team have {newTeam.ReserveTeam.Count} players");
        }
    }
}
