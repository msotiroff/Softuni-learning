namespace P01.CubicArtillery
{
    using System;
    using System.Collections.Generic;

    class StartUp
    {
        private static int bunkerCapacity;
        private static Queue<string> bunkers;
        private static Queue<int> weapons;
        private static int currentBunkerSum;

        static void Main(string[] args)
        {
            bunkerCapacity = int.Parse(Console.ReadLine());
            bunkers = new Queue<string>();
            weapons = new Queue<int>();

            currentBunkerSum = 0;

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Bunker Revision")
            {
                var inputArgs = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in inputArgs)
                {
                    if (char.IsDigit(item[0]))
                    {
                        var currentWeapon = int.Parse(item);
                        
                        if (currentWeapon + currentBunkerSum <= bunkerCapacity) // do not overflows the capacity
                        {
                            currentBunkerSum += currentWeapon;
                            weapons.Enqueue(currentWeapon);
                        }
                        else // overflows the capacity
                        {
                            if (bunkers.Count > 1) // there are more than one bunker => print current and put weapon to the next one
                            {
                                ClearAndPrintWeapons();

                                if (currentWeapon > bunkerCapacity)
                                {
                                    while (bunkers.Count > 1)
                                    {
                                        ClearAndPrintWeapons();
                                    }
                                }
                                else
                                {
                                    weapons.Enqueue(currentWeapon);
                                    currentBunkerSum += currentWeapon;
                                }
                            }
                            else // there is only one bunker, we do not print and clear it
                            {
                                if (currentWeapon <= bunkerCapacity) // weapon is smaller than bunker's capacity => we remove weapons untill it has enough space
                                {
                                    while (currentBunkerSum + currentWeapon > bunkerCapacity)
                                    {
                                        currentBunkerSum -= weapons.Dequeue();
                                    }

                                    weapons.Enqueue(currentWeapon);
                                    currentBunkerSum += currentWeapon;
                                }
                            }
                        }
                    }
                    else
                    {
                        bunkers.Enqueue(item);
                    }
                }
            }
        }

        private static void ClearAndPrintWeapons()
        {
            var allWeaponsInCurrBunker = weapons.Count > 0 ? string.Join(", ", weapons) : "Empty";

            Console.WriteLine($"{bunkers.Dequeue()} -> {allWeaponsInCurrBunker}");

            weapons.Clear();
            currentBunkerSum = 0;
        }
    }
}
