using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Pizza
{
    private string name;
    private int numberOfToppings;
    private Dough dough;
    private IList<Topping> toppings;

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }
    //public Pizza(Dough dough)
    //{
    //    this.Dough = dough;
    //}


    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            else
            {
                this.name = value;
            }
        }
    }

    public int NumberOfToppings
    {
        get
        {
            return this.toppings.Count;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set
        {
            this.dough = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.toppings.Add(topping);
    }

    public double CalculateCalories()
    {
        double calories = this.dough.CalculateCalories() + this.toppings.Sum(t => t.CalculateCalories());

        return calories;
    }
}