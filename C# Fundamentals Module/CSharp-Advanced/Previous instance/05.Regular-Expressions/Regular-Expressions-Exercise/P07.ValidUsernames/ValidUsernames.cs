namespace P07.ValidUsernames
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ValidUsernames
    {
        public static void Main(string[] args)
        {
            var delimiters = new char[] { ' ', '/', '\\', '(', ')' };

            var pattern = @"^[A-Za-z][\w]{2,24}$";

            var userNameValidator = new Regex(pattern);
            
            var validUserNames = Console.ReadLine()
                .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Where(un => userNameValidator.IsMatch(un))
                .ToArray();

            var maxSum = 0;
            var longestCoupleOfUsernames = new string[2];

            for (int i = 0; i < validUserNames.Length - 1; i++)
            {
                var currentUserName = validUserNames[i];
                var nextUserName = validUserNames[i + 1];

                var currentSum = currentUserName.Length + nextUserName.Length;

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    longestCoupleOfUsernames[0] = currentUserName;
                    longestCoupleOfUsernames[1] = nextUserName;
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, longestCoupleOfUsernames));
        }
    }
}
