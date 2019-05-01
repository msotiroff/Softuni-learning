namespace P10.PredicateParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var guestList = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandParams = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var mainCommand = commandParams[0];
                var subCommand = commandParams[1];
                var condition = commandParams[2];

                switch (mainCommand)
                {
                    case "Double":
                        guestList = DoubleInGuestsList(guestList, subCommand, condition);
                        break;
                    case "Remove":
                        guestList = RemoveFromGuestsList(guestList, subCommand, condition);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(guestList.Any()
                ? $"{string.Join(", ", guestList)} are going to the party!"
                : "Nobody is going to the party!");
        }

        private static List<string> RemoveFromGuestsList(List<string> guestList, string subCommand, string condition)
        {
            switch (subCommand)
            {
                case "StartsWith":
                    guestList = guestList.Where(p => !p.StartsWith(condition)).ToList();
                    break;
                case "EndsWith":
                    guestList = guestList.Where(p => !p.EndsWith(condition)).ToList();
                    break;
                case "Length":
                    guestList = guestList.Where(p => p.Length != int.Parse(condition)).ToList();
                    break;
                default:
                    break;
            }

            return guestList;
        }

        private static List<string> DoubleInGuestsList(List<string> guestList, string subCommand, string condition)
        {
            switch (subCommand)
            {
                case "StartsWith":
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        var currentGuest = guestList[i];
                        if (currentGuest.StartsWith(condition))
                        {
                            guestList.Insert(i, currentGuest);
                            i++;
                        }
                    }
                    break;
                case "EndsWith":
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        var currentGuest = guestList[i];
                        if (currentGuest.EndsWith(condition))
                        {
                            guestList.Insert(i, currentGuest);
                            i++;
                        }
                    }
                    break;
                case "Length":
                    for (int i = 0; i < guestList.Count; i++)
                    {
                        var currentGuest = guestList[i];
                        if (currentGuest.Length == int.Parse(condition))
                        {
                            guestList.Insert(i, currentGuest);
                            i++;
                        }
                    }
                    break;
                default:
                    break;
            }

            return guestList;
        }
    }
}
