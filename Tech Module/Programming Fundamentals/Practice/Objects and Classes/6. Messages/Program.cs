﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Messages
{
    public class Messages
    {
        public static void Main()
        {
            List<string> users = new List<string>();
            Dictionary<string, Message> senders = new Dictionary<string, Message>();

            string input = Console.ReadLine();

            while (input != "exit")
            {
                string[] tokens = input.Split(' ').ToArray();

                if (tokens[0] == "register")
                {
                    users.Add(tokens[1]);
                }
                else
                {
                    string sender = tokens[0];
                    string recipient = tokens[2];
                    string content = tokens[3];
                    User newUser = new User();
                    Message message = new Message();

                    if (users.Contains(sender) && users.Contains(recipient))
                    {
                        if (!senders.ContainsKey(sender))
                        {
                            message.Sender = sender;
                            message.Content = new List<string>();
                            senders.Add(message.Sender, message);
                        }
                        if (!senders.ContainsKey(recipient))
                        {
                            Message newMessage = new Message
                            {
                                Sender = recipient,
                                Content = new List<string>()
                            };
                            senders.Add(newMessage.Sender, newMessage);
                        }

                        senders[sender].Content.Add(content);
                    }
                }

                input = Console.ReadLine();
            }

            string[] newInput = Console.ReadLine().Split(' ').ToArray();
            string firstUser = newInput[0];
            string secondUser = newInput[1];
            bool isNoMessage = false;

            if (senders.ContainsKey(firstUser) && senders.ContainsKey(secondUser))
            {
                int max = Math.Max(senders[firstUser].Content.Count, senders[secondUser].Content.Count);
                int firstCount = senders[firstUser].Content.Count;
                int secondCount = senders[secondUser].Content.Count;

                for (int i = 0; i < max; i++)
                {
                    if (senders.ContainsKey(firstUser) && firstCount > 0)
                    {
                        Console.WriteLine($"{senders[firstUser].Sender}: {senders[firstUser].Content[i]}");
                        isNoMessage = true;
                    }
                    if (senders.ContainsKey(secondUser) && secondCount > 0)
                    {
                        Console.WriteLine($"{senders[secondUser].Content[i]} :{senders[secondUser].Sender}");
                        isNoMessage = true;
                    }

                    firstCount--;
                    secondCount--;
                }
            }

            if (!isNoMessage)
            {
                Console.WriteLine("No messages");
            }
        }
    }
}