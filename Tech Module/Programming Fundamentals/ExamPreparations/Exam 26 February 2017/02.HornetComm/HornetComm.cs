using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.HornetComm
{
    public class PrivateMessage
    {
        public string Recipient { get; set; }
        public string Message { get; set; }
    }
    public class Broadcast
    {
        public string Frequency { get; set; }
        public string Message { get; set; }
    }
    class HornetComm
    {
        static void Main(string[] args)
        {
            List<PrivateMessage> allMessages = new List<PrivateMessage>();
            List<Broadcast> allBroadcasts = new List<Broadcast>();

            Regex messageFormat = new Regex(@"^(\d+) <-> ([A-z0-9]+)$");
            Regex broadcastFormat = new Regex(@"^(\D+) <-> ([A-z0-9]+)$");


            string inputLine = Console.ReadLine();

            while (inputLine != "Hornet is Green")
            {
                var matchedMessage = messageFormat.Match(inputLine);
                var matchedBroadcast = broadcastFormat.Match(inputLine);

                if (matchedMessage.Success)
                {
                    GetValidMessage(allMessages, matchedMessage);
                }
                else if (matchedBroadcast.Success)
                {
                    GetValidBroadcast(allBroadcasts, matchedBroadcast);
                }

                inputLine = Console.ReadLine();
            }

            PrintResult(allMessages, allBroadcasts);

        }

        public static void PrintResult(List<PrivateMessage> allMessages, List<Broadcast> allBroadcasts)
        {
            Console.WriteLine("Broadcasts:");

            if (allBroadcasts.Count > 0)
            {
                foreach (var broadcast in allBroadcasts)
                {
                    Console.WriteLine($"{broadcast.Frequency} -> {broadcast.Message}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }

            Console.WriteLine("Messages:");

            if (allMessages.Count > 0)
            {
                foreach (var message in allMessages)
                {
                    Console.WriteLine($"{message.Recipient} -> {message.Message}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }

        public static void GetValidBroadcast(List<Broadcast> allBroadcasts, Match matchedBroadcast)
        {
            string currentMessage = matchedBroadcast.Groups[1].ToString();
            string frequency = matchedBroadcast.Groups[2].ToString();
            string repairedFrequency = string.Empty;

            for (int i = 0; i < frequency.Length; i++)
            {
                char currentCharacter = frequency[i];
                string letterToAdd = string.Empty;
                if (char.IsLetter(currentCharacter))
                {
                    if (char.IsLower(currentCharacter))
                    {
                        letterToAdd = currentCharacter.ToString().ToUpper();
                    }
                    else if (char.IsUpper(currentCharacter))
                    {
                        letterToAdd = currentCharacter.ToString().ToLower();
                    }

                    repairedFrequency += letterToAdd;
                }
                else
                {
                    repairedFrequency += currentCharacter;
                }
            }

            Broadcast currBroadcast = new Broadcast()
            {
                Frequency = repairedFrequency,
                Message = currentMessage
            };

            allBroadcasts.Add(currBroadcast);
        }

        public static void GetValidMessage(List<PrivateMessage> allMessages, Match matchedMessage)
        {
            string recipientCode = matchedMessage.Groups[1].ToString();
            string recipientReversedCode = string.Empty;
            for (int i = recipientCode.Length - 1; i >= 0; i--)
            {
                recipientReversedCode += recipientCode[i];
            }
            string currentMessage = matchedMessage.Groups[2].ToString();

            PrivateMessage currMessage = new PrivateMessage()
            {
                Recipient = recipientReversedCode,
                Message = currentMessage
            };

            allMessages.Add(currMessage);
        }
    }
}
