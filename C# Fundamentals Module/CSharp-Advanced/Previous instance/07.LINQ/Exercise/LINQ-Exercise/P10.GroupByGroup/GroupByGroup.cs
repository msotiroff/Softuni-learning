namespace P10.GroupByGroup
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class GroupByGroup
    {
        public static void Main(string[] args)
        {
            var allPeople = new HashSet<Person>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputArgs = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = string.Format("{0} {1}", inputArgs[0], inputArgs[1]);
                var group = int.Parse(inputArgs.Last());

                allPeople.Add(new Person(name, group));
            }

            var resultSet = allPeople
                .GroupBy(p => p.Group)
                .ToDictionary(x => x.Key, x => x.Select(p => p.Name).ToArray());

            foreach (var group in resultSet.OrderBy(g => g.Key))
            {
                Console.WriteLine($"{group.Key} - {string.Join(", ", group.Value)}");
            }
        }
    }
}
