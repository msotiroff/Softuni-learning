namespace P11.PartyReservation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReadOnlyList<string> people = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var invitedGuests = new List<string>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                var commandParams = command
                    .Split(';');

                var mainCommand = commandParams[0];
                var subCommand = commandParams[1];
                var condition = commandParams[2];

                switch (mainCommand)
                {
                    case "Add filter":
                        invitedGuests = AddInGuestsList(people, invitedGuests, subCommand, condition);
                        break;
                    case "Remove filter":
                        invitedGuests = RemoveFromGuestsList(invitedGuests, subCommand, condition);
                        break;
                    default:
                        break;
                }
            }

            var result = people.Where(p => !invitedGuests.Contains(p)).ToList();

            Console.WriteLine(string.Join(" ", result));
        }

        private static List<string> AddInGuestsList(IReadOnlyList<string> people, List<string> invitedGuests, string subCommand, string condition)
        {
            switch (subCommand)
            {
                case "Starts with":
                    invitedGuests.AddRange(people.Where(p => p.StartsWith(condition)));
                    break;
                case "Ends with":
                    invitedGuests.AddRange(people.Where(p => p.EndsWith(condition)));
                    break;
                case "Length":
                    invitedGuests.AddRange(people.Where(p => p.Length == int.Parse(condition)));
                    break;
                case "Contains":
                    invitedGuests.AddRange(people.Where(p => p.Contains(condition)));
                    break;
                default:
                    break;
            }

            return invitedGuests;
        }

        private static List<string> RemoveFromGuestsList(List<string> invitedGuests, string subCommand, string condition)
        {
            switch (subCommand)
            {
                case "Starts with":
                    invitedGuests.RemoveAll(p => p.StartsWith(condition));
                    break;
                case "Ends with":
                    invitedGuests.RemoveAll(p => p.EndsWith(condition));
                    break;
                case "Length":
                    invitedGuests.RemoveAll(p => p.Length == int.Parse(condition));
                    break;
                case "Contains":
                    invitedGuests.RemoveAll(p => p.Contains(condition));
                    break;
                default:
                    break;
            }

            return invitedGuests;
        }
    }
}
