using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.SpyGram
{
    class SpyGram
    {
        static void Main(string[] args)
        {
            //               Sender  Message
            SortedDictionary<string, List<string>> allMessages 
                = new SortedDictionary<string, List<string>>();

            Regex validateMessage = new Regex(@"TO:\s([A-Z]+);\sMESSAGE:\s(.+);");

            string privateKey = Console.ReadLine();

            string inputMessage = Console.ReadLine();

            while (inputMessage != "END")
            {
                Match isValidMessage = validateMessage.Match(inputMessage);

                if (isValidMessage.Success)
                {
                    string currentSenderName = isValidMessage.Groups[1].ToString();

                    string currentEncryptedMessage = string.Empty;

                    for (int i = 0; i < inputMessage.Length; i++)
                    {
                        char currentSymbol = inputMessage[i];
                        int keyDigit = int.Parse(privateKey[i % privateKey.Length].ToString());

                        char encryptedSymbol = (char)(currentSymbol + keyDigit);
                        currentEncryptedMessage += encryptedSymbol;
                    }

                    if (! allMessages.ContainsKey(currentSenderName))
                    {
                        allMessages[currentSenderName] = new List<string>();
                    }
                    allMessages[currentSenderName].Add(currentEncryptedMessage);
                }

                inputMessage = Console.ReadLine();
            }


            foreach (var messages in allMessages.Values)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            }
        }
    }
}
