using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Rabbit_Hole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> commands = Console.ReadLine().Split(' ').ToList();
            int energy = int.Parse(Console.ReadLine());

            for (int i = 0; ;)
            {
                if (commands[i] == "RabbitHole")
                {
                    Console.WriteLine("You have 5 years to save Kennedy!");
                    break;
                }
                else
                {
                    string[] movement = commands[i].Split('|').ToArray();
                    string jump = movement[0];
                    int steps = int.Parse(movement[1]);

                    if (jump == "Bomb")
                    {
                        energy -= steps;
                        if (energy <= 0)
                        {
                            Console.WriteLine("You are dead due to bomb explosion!");
                            break;
                        }
                        commands.RemoveAt(i);
                        i = 0;
                    }
                    else if (jump == "Left")
                    {
                        energy -= steps;
                        i = Math.Abs(i - steps) % commands.Count;
                    }
                    else if (jump == "Right")
                    {
                        i = (i + steps) % commands.Count;
                    }
                }
                if (energy <= 0)
                {
                    Console.WriteLine("You are tired. You can't continue the mission.");
                    break;
                }
                if (commands[commands.Count - 1] != "RabbitHole")
                {
                    commands.RemoveAt(commands.Count - 1);
                }
                commands.Add($"Bomb|{energy}");
            }
        }
    }
}
