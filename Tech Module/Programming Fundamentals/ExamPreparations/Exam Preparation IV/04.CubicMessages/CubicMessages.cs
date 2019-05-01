using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _04.CubicMessages
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            while (inputLine != "Over!")
            {
                int lenghtOfMessage = int.Parse(Console.ReadLine());

                string CurrentPattern = @"^(\d+)([A-Za-z]{" + lenghtOfMessage.ToString() + @"})(\d*)[^A-Za-z]*$";

                Regex currentReg = new Regex(CurrentPattern);      //  ^(\d+)([A-Za-z]{lenghtOfMessage})(\d*)[^A-Za-z]*$

                var matched = currentReg.Match(inputLine);

                if (matched.Success)
                {
                    string verificationCode = string.Empty;

                    string message = matched.Groups[2].Value.ToString();
                    string indexesAsString = matched.Groups[1].Value.ToString()
                                    + matched.Groups[3].Value.ToString();

                    var indexesAsChar = indexesAsString.Trim().ToCharArray();

                    List<int> currentIndexes = new List<int>();

                    for (int i = 0; i < indexesAsChar.Length; i++)
                    {
                        int currentIndex = int.Parse(indexesAsChar[i].ToString());
                        currentIndexes.Add(currentIndex);
                    }
                    for (int i = 0; i < currentIndexes.Count; i++)
                    {
                        int currentIndex = currentIndexes[i];
                        if (currentIndex >= 0 && currentIndex < message.Length)
                        {
                            verificationCode += message[currentIndex];
                        }
                        else
                        {
                            verificationCode += " ";
                        }
                    }

                    Console.WriteLine($"{message} == {verificationCode}");
                }
                

                inputLine = Console.ReadLine();
            }
            
        }
    }
}
