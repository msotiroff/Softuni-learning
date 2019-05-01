using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Dough
{
    private string flourType;
    private string bakingTechnique;
    private int weight;

    public Dough (string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get { return this.flourType; }

        private set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            else
            {
                this.flourType = value;
            }
        }
    }

    public string BakingTechnique
    {
        get { return this.bakingTechnique; }

        private set
        {
            if (value.ToLower() != "crispy" 
                && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            else
            {
                this.bakingTechnique = value;
            }
        }
    }

    public int Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
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

        if (this.FlourType.ToLower() == "white")
        {
            calories *= 1.5;
        }

        if (this.BakingTechnique.ToLower() == "crispy")
        {
            calories *= 0.9;
        }
        else if (this.BakingTechnique.ToLower() == "chewy")
        {
            calories *= 1.1;
        }

        return calories;
    }
}