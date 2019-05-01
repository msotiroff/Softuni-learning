using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.SMS_Typing
{
    class SMSTyping
    {
        static void Main(string[] args)
        {
            int numberOfSymbols = int.Parse(Console.ReadLine());

            string wordToPrint = string.Empty;

            for (int i = 0; i < numberOfSymbols; i++)
            {
                string currentInput = Console.ReadLine();
                int mainDigit = int.Parse(currentInput[0].ToString());
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + currentInput.Length + 96;
                if (mainDigit == 0)
                {
                    letterIndex = 32;
                }
                char currentLetter = (char)letterIndex;
                wordToPrint += currentLetter;
            }

            Console.WriteLine(wordToPrint);
        }
    }
}
