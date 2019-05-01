using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            //        Message   Code
            Dictionary<string, string> allMessages = new Dictionary<string, string>();

            string inputMessage = Console.ReadLine();

            while (inputMessage != "Over!")
            {
                int messageLenght = int.Parse(Console.ReadLine());
                string pattern = @"^(\d+)([A-Za-z]{" + messageLenght + @"})(\d*)[^A-Za-z]*$";
                Regex validateMessage = new Regex(pattern);

                Match matchedMessage = validateMessage.Match(inputMessage);

                if (matchedMessage.Success)
                {
                    string currentMessage = matchedMessage.Groups[2].ToString();
                    string currentCode = string.Empty;

                    string digits = matchedMessage.Groups[1].ToString() + matchedMessage.Groups[3].ToString();

                    for (int i = 0; i < digits.Length; i++)
                    {
                        int index = int.Parse(digits[i].ToString());

                        if (index >= 0 && index < currentMessage.Length)
                        {
                            currentCode += currentMessage[index];
                        }
                        else
                        {
                            currentCode += " ";
                        }
                    }

                    allMessages[currentMessage] = currentCode;
                }

                inputMessage = Console.ReadLine();
            }

            foreach (var message in allMessages)
            {
                Console.WriteLine($"{message.Key} == {message.Value}");
            }
        }
    }
}
