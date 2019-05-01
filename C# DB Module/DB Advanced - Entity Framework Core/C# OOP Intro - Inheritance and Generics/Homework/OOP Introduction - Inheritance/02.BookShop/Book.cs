using System;
using System.Linq;

public class Book
{
    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public virtual decimal Price
    {
        get { return price; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }


    public string Author
    {
        get { return this.author; }
        protected set
        {
            string[] names = value.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (names.Length > 1 && Char.IsDigit(names[1].First()))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }


    public string Title
    {
        get { return title; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }

    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine
            + $"Title: {this.title}" + Environment.NewLine
            + $"Author: {this.author}" + Environment.NewLine
            + $"Price: {this.price:f2}";
    }
}