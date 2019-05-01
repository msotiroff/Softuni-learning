namespace P02.BookShop.Models
{
    using System;
    using System.Linq;
    using System.Text;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public virtual decimal Price
        {
            get => this.price;

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
            get => this.author;

            private set
            {
                if (char.IsDigit(value.Split().Last()[0]))
                {
                    throw new ArgumentException("Author not valid!");
                }

                this.author = value;
            }
        }

        public string Title
        {
            get => this.title;

            private set
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
            var sb = new StringBuilder();
            sb.Append("Type: ").AppendLine(this.GetType().Name)
                .Append("Title: ").AppendLine(this.Title)
                .Append("Author: ").AppendLine(this.Author)
                .Append("Price: ").Append($"{this.Price:f2}")
                .AppendLine();

            return sb.ToString();

        }
    }
}

