using System;

namespace _01.Trainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfParticipants = int.Parse(Console.ReadLine());

            double technicalEarning = 0;
            double theoreticalEarning = 0;
            double practicalEarning = 0;


            for (int i = 0; i < numberOfParticipants; i++)
            {
                int distanceToTravel = int.Parse(Console.ReadLine()) * 1600;
                double cargo = double.Parse(Console.ReadLine()) * 1000;
                string team = Console.ReadLine();

                double earnedMoney = (cargo * 1.5) - (0.7 * distanceToTravel * 2.5);

                if (team == "Technical")
                {
                    technicalEarning += earnedMoney;
                }
                else if (team == "Theoretical")
                {
                    theoreticalEarning += earnedMoney;
                }
                else if (team == "Practical")
                {
                    practicalEarning += earnedMoney;
                }
            }

            if (technicalEarning > theoreticalEarning && technicalEarning > practicalEarning)
            {
                Console.WriteLine($"The Technical Trainers win with ${technicalEarning:f3}.");
            }
            else if (theoreticalEarning > technicalEarning && theoreticalEarning > practicalEarning)
            {
                Console.WriteLine($"The Theoretical Trainers win with ${theoreticalEarning:f3}.");
            }
            else if (practicalEarning > technicalEarning && practicalEarning > theoreticalEarning)
            {
                Console.WriteLine($"The Practical Trainers win with ${practicalEarning:f3}.");
            }

        }
    }
}
