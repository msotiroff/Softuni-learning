﻿using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    public static Driver CreateInstance(List<string> args)
    {
        Driver driver = null;

        var driverType = args[0];
        var driverName = args[1];

        var carHp = int.Parse(args[2]);
        var carFuelAmount = double.Parse(args[3]);

        var tyreArgs = args.Skip(4).ToArray();

        Tyre tyre = TyreFactory.CreateInstance(tyreArgs);
        
        Car car = new Car(carHp, carFuelAmount, tyre);

        if (driverType == "Aggressive")
        {
            driver = new AggressiveDriver(driverName, car);
        }
        else if (driverType == "Endurance")
        {
            driver = new EnduranceDriver(driverName, car);
        }

        return driver != null ? driver : throw new ArgumentException();
    }
}