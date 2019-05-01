using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    class AndreyAndBilliard
    {
        static void Main(string[] args)
        {
            List<Customer> allCustomers = new List<Customer>();

            int numberOfGivenProducts = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> allProducts = new Dictionary<string, decimal>();

            for (int i = 0; i < numberOfGivenProducts; i++)
            {
                string[] input = Console.ReadLine().Split('-');
                string productName = input[0];
                decimal productPrice = decimal.Parse(input[1]);

                allProducts[productName] = productPrice;
            }

            string buyingInput = Console.ReadLine();

            while (buyingInput != "end of clients")
            {
                string[] currClientProperties = buyingInput.Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                string currClientName = currClientProperties[0];
                string currPurchase = currClientProperties[1];
                int currCount = int.Parse(currClientProperties[2]);

                if (!allProducts.ContainsKey(currPurchase))
                {
                    buyingInput = Console.ReadLine();
                    continue;
                }



                if (allCustomers.Any(c => c.Name == currClientName))
                {
                    foreach (var customer in allCustomers)
                    {
                        if (customer.Name == currClientName)
                        {
                            if (!customer.ShopList.ContainsKey(currPurchase))
                            {
                                customer.ShopList[currPurchase] = 0;
                            }
                            customer.ShopList[currPurchase] += currCount;
                            customer.Bill += allProducts[currPurchase] * currCount;
                        }
                    }
                }
                else
                {
                    Customer currentCustomer = new Customer()
                    {
                        Name = currClientName,
                        ShopList = new Dictionary<string, int>(),
                        Bill = 0
                    };

                    currentCustomer.ShopList.Add(currPurchase, currCount);
                    currentCustomer.Bill += allProducts[currPurchase] * currCount;

                    allCustomers.Add(currentCustomer);

                }


                buyingInput = Console.ReadLine();
            }

            decimal totalBill = 0;

            foreach (var customer in allCustomers.OrderBy(c => c.Name))
            {
                Console.WriteLine(customer.Name);
                foreach (var purchase in customer.ShopList)
                {
                    Console.WriteLine($"-- {purchase.Key} - {purchase.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
                totalBill += customer.Bill;
            }
            Console.WriteLine($"Total bill: {totalBill:f2}");
        }
    }
}
