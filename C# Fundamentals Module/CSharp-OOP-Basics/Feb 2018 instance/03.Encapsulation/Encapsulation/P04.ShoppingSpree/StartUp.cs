namespace P04.ShoppingSpree
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var allPeople = new List<Person>();
            var allProducts = new List<Product>();

            SeedData(allPeople, allProducts);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                ReadCommand(allPeople, allProducts, command);
            }

            allPeople.ForEach(p => Console.WriteLine(p));
        }

        private static void ReadCommand(List<Person> allPeople, List<Product> allProducts, string command)
        {
            var kvp = command.Split();

            var personName = kvp[0];
            var productName = kvp[1];

            try
            {
                var person = allPeople.First(p => p.Name == personName);
                var product = allProducts.First(pr => pr.Name == productName);

                person.BuyProduct(product);
                Console.WriteLine($"{person.Name} bought {product.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SeedData(List<Person> allPeople, List<Product> allProducts)
        {
            try
            {
                var inputPeople = Console.ReadLine()
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var inputProducts = Console.ReadLine()
                    .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var currentPerson in inputPeople)
                {
                    var personParams = currentPerson.Split('=').ToArray();
                    var personName = personParams[0];
                    var personMoney = decimal.Parse(personParams[1]);

                    var person = new Person(personName, personMoney);
                    allPeople.Add(person);
                }

                foreach (var currentProduct in inputProducts)
                {
                    var productParams = currentProduct
                        .Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    var productName = productParams[0];
                    var productCost = decimal.Parse(productParams[1]);

                    var product = new Product(productName, productCost);
                    allProducts.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
        }
    }
}
