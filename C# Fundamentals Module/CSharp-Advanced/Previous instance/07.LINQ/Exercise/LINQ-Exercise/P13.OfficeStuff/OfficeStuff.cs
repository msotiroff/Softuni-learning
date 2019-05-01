namespace P13.OfficeStuff
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OfficeStuff
    {
        public static void Main(string[] args)
        {
            var delimiters = new char[] { ' ', '|', '-' };

            var orderHistory = new Dictionary<string, Dictionary<string, int>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                var inputArgs = Console.ReadLine()
                    .Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                var organization = inputArgs[0];
                var amount = int.Parse(inputArgs[1]);
                var product = inputArgs[2];

                if (!orderHistory.ContainsKey(organization))
                {
                    orderHistory[organization] = new Dictionary<string, int>();
                }
                if (!orderHistory[organization].ContainsKey(product))
                {
                    orderHistory[organization][product] = 0;
                }

                orderHistory[organization][product] += amount;
            }
            
            var result = orderHistory
                .OrderBy(c => c.Key)
                .Select(o => new
                {
                    Company = o.Key,
                    Orders = o.Value.Select(c => $"{c.Key}-{c.Value}")
                    .ToArray()
                })
                .ToList();

            // Output format: <company>: <product>-<amount>, <product>-<amount>, … <product>-<amount>
            result
                .ForEach(c => Console.WriteLine($"{c.Company}: {string.Join(", ", c.Orders)}"));
        }
    }
}
