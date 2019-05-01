﻿using System;
using System.Collections.Generic;

public class Person
{
    private readonly IList<Product> bagOfProducts;
    private string name;
    private decimal money;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public void BuyProduct(Product product)
    {
        if (this.Money < product.Price)
        {
            throw new InvalidOperationException($"{this.Name} can\'t afford {product.Name}");
        }

        this.Money -= product.Price;
        this.bagOfProducts.Add(product);
    }

    public string PrintProducts()
    {
        if (this.bagOfProducts.Count > 0)
        {
            return $"{this.Name} - {string.Join(", ", this.bagOfProducts)}";
        }

        return $"{this.Name} - Nothing bought";
    }
}
