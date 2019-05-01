using System;

namespace _02.EmailMe
{
    class EmailMe
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            
            string userName = email.Substring(0, email.IndexOf('@'));
            string domain = email.Substring(email.IndexOf('@') + 1);

            int nameSum = 0;
            int domainSum = 0;
            for (int i = 0; i < userName.Length; i++)
            {
                nameSum += Convert.ToInt32(userName[i]);
            }
            for (int i = 0; i < domain.Length; i++)
            {
                domainSum += Convert.ToInt32(domain[i]);
            }

            int diff = nameSum - domainSum;

            Console.WriteLine(diff >= 0 ? "Call her!" : "She is not the one.");
            
        }
    }
}