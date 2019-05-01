namespace P02.SoftUniParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniParty
    {
        public static void Main(string[] args)
        {
            var vipGuests = new SortedSet<string>();

            var regularGuests = new SortedSet<string>();

            var currentGuest = Console.ReadLine();

            while (currentGuest != "PARTY")
            {
                if (char.IsDigit(currentGuest[0]))
                {
                    vipGuests.Add(currentGuest);
                }
                else
                {
                    regularGuests.Add(currentGuest);
                }

                currentGuest = Console.ReadLine();
            }

            var enteredGuest = Console.ReadLine();

            while (enteredGuest != "END")
            {
                if (vipGuests.Contains(enteredGuest))
                {
                    vipGuests.Remove(enteredGuest);
                }
                else if (regularGuests.Contains(enteredGuest))
                {
                    regularGuests.Remove(enteredGuest);
                }

                enteredGuest = Console.ReadLine();
            }

            PrintResult(vipGuests, regularGuests);
        }

        private static void PrintResult(SortedSet<string> vipGuests, SortedSet<string> regularGuests)
        {
            Console.WriteLine(vipGuests.Count + regularGuests.Count);

            if (vipGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, vipGuests));
            }

            if (regularGuests.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, regularGuests));
            }
        }
    }
}
