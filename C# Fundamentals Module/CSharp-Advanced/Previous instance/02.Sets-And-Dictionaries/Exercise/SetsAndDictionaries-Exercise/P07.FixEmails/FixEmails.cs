namespace P07.FixEmails
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class FixEmails
    {
        public static void Main(string[] args)
        {
            var emailStorage = new Dictionary<string, string>();

            string name = Console.ReadLine();

            while (name != "stop")
            {
                var email = Console.ReadLine();

                if (!email.ToLower().EndsWith("uk") && !email.ToLower().EndsWith("us"))
                {
                    emailStorage[name] = email;
                }
                
                name = Console.ReadLine();
            }

            foreach (var person in emailStorage)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
