using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Topping
{
    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get { return this.type; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" 
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            else
            {
                this.type = value;
            }
        }
    }

    public int Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            else
            {
                this.weight = value;
            }
        }
    }

    public double CalculateCalories()
    {
        double calories = 2 * this.weight;

        if (this.Type.ToLower() == "meat")
        {
            calories *= 1.2;
        }
        else if (this.Type.ToLower() == "veggies")
        {
            calories *= 0.8;
        }
        else if (this.Type.ToLower() == "cheese")
        {
            calories *= 1.1;
        }
        else if (this.Type.ToLower() == "sauce")
        {
            calories *= 0.9;
        }

        return calories;
    }
}