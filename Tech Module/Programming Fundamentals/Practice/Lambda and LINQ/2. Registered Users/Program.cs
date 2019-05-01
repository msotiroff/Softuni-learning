using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace _2.Registered_Users
{
    public class RegisteredUsers
    {
        public static void Main()
        {
            Dictionary<string, DateTime> users = new Dictionary<string, DateTime>();

            var input = Console.ReadLine()
                .Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "end")
            {
                var name = input[0];
                var date = DateTime.
                    ParseExact(input[1], "dd/mm/yyyy", CultureInfo.InvariantCulture);

                users[name] = date;

                input = Console.ReadLine()
                .Split(new[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            var result = users
                .Reverse()
                .OrderBy(x => x.Value)
                .Take(5)
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
