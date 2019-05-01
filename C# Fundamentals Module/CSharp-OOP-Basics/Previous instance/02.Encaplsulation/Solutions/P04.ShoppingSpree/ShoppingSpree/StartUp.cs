namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var inputPeople = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            var allPeople = new List<Person>();
            var allProducts = new List<Product>();

            try
            {
                foreach (var person in inputPeople)
                {
                    var name = person.Split('=').First();
                    var money = decimal.Parse(person.Split('=').Last());

                    var currentPerson = new Person(name, money);
                    allPeople.Add(currentPerson);
                }
                foreach (var product in inputProducts)
                {
                    var name = product.Split('=').First();
                    var cost = decimal.Parse(product.Split('=').Last());

                    var currentProduct = new Product(name, cost);
                    allProducts.Add(currentProduct);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var inputParams = inputLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = allPeople.FirstOrDefault(p => p.Name == inputParams[0]);
                var product = allProducts.FirstOrDefault(pr => pr.Name == inputParams[1]);

                try
                {
                    person.AffordProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            allPeople.ForEach(p => Console.WriteLine(p.PrintBagOfProducts()));
        }
    }
}
