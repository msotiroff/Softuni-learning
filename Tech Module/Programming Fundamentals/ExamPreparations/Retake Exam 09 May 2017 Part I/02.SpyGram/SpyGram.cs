using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.SpyGram
{
    public class Message
    {
        public string Recipient { get; set; }
        public string EncryptedMessage { get; set; }
    }

    class SpyGram
    {
        static void Main(string[] args)
        {
            List<Message> sendersAndMessages = new List<Message>();

            string privateKey = Console.ReadLine();

            var privateKeyDigits = privateKey
                .ToCharArray()
                .Select(c => c.ToString())
                .Select(int.Parse)
                .ToArray();
            
            Regex messageValidation = new Regex(@"TO: ([A-Z]+); MESSAGE: (.*);");

            string message = Console.ReadLine();

            while (message != "END")
            {
                var validMessage = messageValidation.Match(message);

                if (validMessage.Success)
                {
                    string encryptedMessage = string.Empty;

                    for (int i = 0; i < message.Length; i++)
                    {
                        char currentChar = message[i];
                        int digitToUse = privateKeyDigits[i % privateKeyDigits.Length];
                        char changedChar = (char)(Convert.ToInt32(currentChar) + digitToUse);

                        encryptedMessage += changedChar;
                    }

                    string recipient = validMessage.Groups[1].ToString();


                    Message currentMessage = new Message()
                    {
                        Recipient = recipient,
                        EncryptedMessage = encryptedMessage
                    };

                    sendersAndMessages.Add(currentMessage);

                }

                message = Console.ReadLine();
            }


            foreach (var currentMessage in sendersAndMessages.OrderBy(m => m.Recipient))
            {
                Console.WriteLine(currentMessage.EncryptedMessage);
            }
        }
    }
}
