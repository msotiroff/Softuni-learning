using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.HornetComm
{
    class HornetComm
    {
        static void Main(string[] args)
        {
            //        Recipients   Messages
            Dictionary<string, List<string>> allPrivateMessages = new Dictionary<string, List<string>>();
            //       frequencies   Messages
            Dictionary<string, List<string>> allBroadcasts = new Dictionary<string, List<string>>();


            Regex validatePrivateMessage = new Regex(@"^(?<RecipientCode>\d+)\s<->\s(?<Message>[A-Za-z0-9]+)$");
            Regex validateBroadcast = new Regex(@"^(?<Message>[^0-9]+)\s<->\s(?<Frequency>[A-Za-z0-9]+)$");

            string inputLine = Console.ReadLine();

            while (inputLine != "Hornet is Green")
            {
                var matchPrivateMessage = validatePrivateMessage.Match(inputLine);
                var matchBroadcast = validateBroadcast.Match(inputLine);

                if (matchPrivateMessage.Success)
                {
                    AddPrivateMessage(allPrivateMessages, matchPrivateMessage);

                }
                else if (matchBroadcast.Success)
                {
                    AddBroadcast(allBroadcasts, matchBroadcast);
                }


                inputLine = Console.ReadLine();
            }

            PrintResults(allPrivateMessages, allBroadcasts);

        }

        public static void AddPrivateMessage(Dictionary<string, List<string>> allPrivateMessages, Match matchPrivateMessage)
        {
            string currentRecipientCode = matchPrivateMessage.Groups["RecipientCode"].ToString();
            string currentMessage = matchPrivateMessage.Groups["Message"].ToString();

            string reversedRecipientCode = ReverceCode(currentRecipientCode);

            if (!allPrivateMessages.ContainsKey(reversedRecipientCode))
            {
                allPrivateMessages[reversedRecipientCode] = new List<string>();
            }
            allPrivateMessages[reversedRecipientCode].Add(currentMessage);
        }

        public static void AddBroadcast(Dictionary<string, List<string>> allBroadcasts, Match matchBroadcast)
        {
            string currentMessage = matchBroadcast.Groups["Message"].ToString();
            string currentFrequency = matchBroadcast.Groups["Frequency"].ToString();

            string finanlFrequency = ChangeFrequency(currentFrequency);

            if (!allBroadcasts.ContainsKey(finanlFrequency))
            {
                allBroadcasts[finanlFrequency] = new List<string>();
            }
            allBroadcasts[finanlFrequency].Add(currentMessage);
        }

        public static void PrintResults(Dictionary<string, List<string>> allPrivateMessages, Dictionary<string, List<string>> allBroadcasts)
        {
            Console.WriteLine("Broadcasts:");

            if (allBroadcasts.Count > 0)
            {
                foreach (var frequency in allBroadcasts)
                {
                    foreach (var message in frequency.Value)
                    {
                        Console.WriteLine($"{frequency.Key} -> {message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");

            if (allPrivateMessages.Count > 0)
            {
                foreach (var recipient in allPrivateMessages)
                {
                    foreach (var message in recipient.Value)
                    {
                        Console.WriteLine($"{recipient.Key} -> {message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        public static string ReverceCode(string currentRecipientCode)
        {
            string result = string.Empty;

            for (int i = currentRecipientCode.Length - 1; i >= 0; i--)
            {
                result += currentRecipientCode[i];
            }

            return result;
        }

        public static string ChangeFrequency(string currentFrequency)
        {
            string result = string.Empty;

            for (int i = 0; i < currentFrequency.Length; i++)
            {
                char currentLetter = currentFrequency[i];

                if (char.IsUpper(currentLetter))
                {
                    string changedLetter = currentLetter.ToString().ToLower();
                    result += changedLetter;
                }
                else if (char.IsLower(currentLetter))
                {
                    string changedLetter = currentLetter.ToString().ToUpper();
                    result += changedLetter;
                }
                else
                {
                    result += currentLetter;
                }
            }

            return result;
        }
    }
}
