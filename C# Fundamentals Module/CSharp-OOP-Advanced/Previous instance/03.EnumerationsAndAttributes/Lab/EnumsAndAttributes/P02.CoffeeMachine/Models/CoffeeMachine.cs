using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int storedCoins;

    public IList<CoffeeType> CoffeesSold { get; } = new List<CoffeeType>();

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeeType;
        CoffeePrice coffeePrice;

        var isSizeValid = Enum.TryParse<CoffeePrice>(size, out coffeePrice);
        var isTypeValid = Enum.TryParse<CoffeeType>(type, out coffeeType);

        if (!isSizeValid)
        {
            throw new ArgumentException("Invalid size of coffee!");
        }
        if (!isTypeValid)
        {
            throw new ArgumentException("Invalid type of coffee!");
        }
        if ((int)coffeePrice > this.storedCoins)
        {
            throw new ArgumentException("Not enough coins!");
        }

        this.CoffeesSold.Add(coffeeType);
        this.storedCoins = 0;
    }

    public void InsertCoin(string insertedCoin)
    {
        Coin coin;
        if (Enum.TryParse<Coin>(insertedCoin, out coin))
        {
            this.storedCoins += (int)coin;
        }
        else
        {
            throw new ArgumentException("Invalid coin!");
        }
    }
}
