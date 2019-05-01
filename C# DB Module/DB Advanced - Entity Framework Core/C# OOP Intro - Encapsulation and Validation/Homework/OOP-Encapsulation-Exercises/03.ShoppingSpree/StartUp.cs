﻿using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] inputPeople = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        IList<Person> people = new List<Person>();

        foreach (string person in inputPeople)
        {
            string[] args = person.Split('=');

            try
            {
                Person currentPerson = new Person(args[0], decimal.Parse(args[1]));
                people.Add(currentPerson);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        IList<Product> products = new List<Product>();
        string[] inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string inputProduct in inputProducts)
        {
            string[] args = inputProduct.Split('=');

            try
            {
                Product currentProduct = new Product(args[0], decimal.Parse(args[1]));
                products.Add(currentProduct);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
        }

        string inputLine = Console.ReadLine();

        while (inputLine != "END")
        {
            string[] args = inputLine.Split();
            string personName = args[0];
            string productName = args[1];

            Person currentPerson = people.FirstOrDefault(p => p.Name.Equals(personName));
            Product currentProduct = products.FirstOrDefault(pr => pr.Name.Equals(productName));

            try
            {
                currentPerson.BuyProduct(currentProduct);
                Console.WriteLine($"{currentPerson.Name} bought {currentProduct.Name}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            inputLine = Console.ReadLine();
        }

        foreach (Person person in people)
        {
            Console.WriteLine(person.PrintProducts());
        }
    }
}