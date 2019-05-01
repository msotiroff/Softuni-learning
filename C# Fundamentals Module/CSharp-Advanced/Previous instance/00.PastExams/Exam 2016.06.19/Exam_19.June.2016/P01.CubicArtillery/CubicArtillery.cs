namespace P01.CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicArtillery // => gets 80/100, cause of time limit overflow!
    {
        private static int bunkersCapacity;

        public static void Main(string[] args)
        {
            bunkersCapacity = int.Parse(Console.ReadLine());

            // [BunkerName] => Bunker
            var allBunkers = new Queue<Bunker>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Bunker Revision")
            {
                var inputParams = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in inputParams)
                {
                    int currentWeapon;
                    if (int.TryParse(item, out currentWeapon))
                    {
                        for (int i = 0; i < allBunkers.Count; i++)
                        {
                            var currentBunker = allBunkers.Peek();

                            if (currentBunker.Filling + currentWeapon <= currentBunker.Capacity)
                            {
                                currentBunker.Weapons.Enqueue(currentWeapon);
                                break;
                            }
                            else
                            {
                                if (i == allBunkers.Count - 1)
                                {
                                    // Make free capacity:
                                    while (currentBunker.Filling + currentWeapon > currentBunker.Capacity)
                                    {
                                        if (currentBunker.Weapons.Any())
                                        {
                                            currentBunker.Weapons.Dequeue();
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    if (currentBunker.Filling + currentWeapon <= currentBunker.Capacity)
                                    {
                                        currentBunker.Weapons.Enqueue(currentWeapon);
                                        break;
                                    }
                                    else
                                    {
                                        if (allBunkers.Count > 1)
                                        {
                                            PrintBunker(currentBunker);
                                            allBunkers.Dequeue();
                                            i--;
                                        }
                                    }
                                }
                                else
                                {
                                    PrintBunker(currentBunker);
                                    allBunkers.Dequeue();
                                    i--;
                                }
                            }
                        }
                    }
                    else
                    {
                        allBunkers.Enqueue(new Bunker(item, bunkersCapacity));
                    }
                }
            }
        }

        private static void PrintBunker(Bunker bunker)
        {
            // {bunker} -> {weapon1}, {weapossn2}…
            var weapons = bunker.Weapons.Any() ? string.Join(", ", bunker.Weapons) : "Empty";

            Console.WriteLine($"{bunker.Name} -> {weapons}");
        }
    }

    internal class Bunker
    {
        public Bunker(string name, int bunkersCapacity)
        {
            this.Name = name;
            this.Capacity = bunkersCapacity;
            this.Weapons = new Queue<int>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public Queue<int> Weapons { get; set; }

        public int Filling { get => this.Weapons.Sum(); }
    }
}
