using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    class ValidUsernames
    {
        static void Main(string[] args)
        {
            var delimiters = @" ,/\()".ToCharArray();

            string[] usernames = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> allValidUserNames = new List<string>();

            Regex validateUserName = new Regex(@"\b[A-Za-z]\w{2,24}\b");

            for (int i = 0; i < usernames.Length; i++)
            {
                string currPotentialUserName = usernames[i];

                Match isValid = validateUserName.Match(currPotentialUserName);

                if (isValid.Success)
                {
                    allValidUserNames.Add(currPotentialUserName);
                }
            }

            string longestUserNames = string.Empty;
            int maxSum = 0;


            for (int i = 0; i < allValidUserNames.Count - 1; i++)
            {
                string currentName = allValidUserNames[i];
                string nextName = allValidUserNames[i + 1];
                int currentSum = currentName.Length + nextName.Length;
                
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    longestUserNames = currentName + Environment.NewLine + nextName;
                }
            }

            Console.WriteLine(longestUserNames);
        }
    }
}
