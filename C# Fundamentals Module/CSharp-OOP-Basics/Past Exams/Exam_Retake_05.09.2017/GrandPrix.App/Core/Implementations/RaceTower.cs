using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower : IRaceTower
{
    private List<Driver> allDrivers;
    private Dictionary<string, string> dnf;
    private int trackLength;
    private string weather;
    private int totalLaps;

    public int CurrentLap { get; private set; }
    public IDriver Winner { get; private set; }

    public RaceTower()
    {
        this.allDrivers = new List<Driver>();
        this.dnf = new Dictionary<string, string>();
        this.weather = "Sunny";
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var newWeather = commandArgs[0];

        this.weather = newWeather;
    }
    
    public string CompleteLaps(List<string> commandArgs)
    {
        var result = new StringBuilder();

        var numberOfLabs = int.Parse(commandArgs[0]);

        if (numberOfLabs + this.CurrentLap > totalLaps)
        {
            return $"There is no time! On lap {this.CurrentLap}.";
        }

        for (int i = 0; i < numberOfLabs; i++)
        {
            foreach (var driver in this.allDrivers)
            {
                driver.TotalTime += 60 / (this.trackLength / driver.Speed);

                try
                {
                    driver.Car.SpendFuel(trackLength, driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (Exception ex)
                {
                    this.dnf.Add(driver.Name, ex.Message);
                }
            }

            this.allDrivers.RemoveAll(d => dnf.Keys.Contains(d.Name));

            this.CurrentLap++;

            var leftDrivers = this.allDrivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int j = 0; j < leftDrivers.Count - 1; j++)
            {
                var currentDriver = leftDrivers[j];
                var nextDriver = leftDrivers[j + 1];
                var overtakeInterval = 2.0;

                var hasCrashed = false;

                var currentDriverType = currentDriver.GetType().Name;
                var currentDriverTyreType = currentDriver.Car.Tyre.GetType().Name;

                if (currentDriverType == nameof(AggressiveDriver)
                    && currentDriverTyreType == nameof(UltrasoftTyre))
                {
                    overtakeInterval = 3.0;
                    if (this.weather == "Foggy")
                    {
                        hasCrashed = true;
                    }
                }
                else if (currentDriverType == nameof(EnduranceDriver)
                    && currentDriverTyreType == nameof(HardTyre))
                {
                    overtakeInterval = 3.0;
                    if (this.weather == "Rainy")
                    {
                        hasCrashed = true;
                    }
                }

                if (currentDriver.TotalTime - nextDriver.TotalTime <= overtakeInterval)
                {
                    if (hasCrashed)
                    {
                        this.dnf.Add(currentDriver.Name, "Crashed");

                        this.allDrivers.RemoveAll(d => dnf.Keys.Contains(d.Name));
                    }
                    else
                    {
                        currentDriver.TotalTime -= overtakeInterval;
                        nextDriver.TotalTime += overtakeInterval;

                        result.AppendLine(
                            $"{currentDriver.Name} has overtaken {nextDriver.Name} on lap {this.CurrentLap}.");

                        j++;
                    }
                }
            }
        }

        if (this.CurrentLap == this.totalLaps)
        {
            this.Winner = this.allDrivers.OrderBy(d => d.TotalTime).FirstOrDefault();
        }

        return result.ToString().Trim();
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driver = allDrivers.First(d => d.Name == commandArgs[1]);
        driver.TotalTime += 20;

        if (reasonToBox == "ChangeTyres")
        {
            var tyreArgs = commandArgs.Skip(2).ToArray();

            Tyre tyre = TyreFactory.CreateInstance(tyreArgs);

            driver.Car.ChangeTyre(tyre);
        }
        else if (reasonToBox == "Refuel")
        {
            var amountToRefuel = double.Parse(commandArgs[2]);

            driver.Car.Refuel(amountToRefuel);
        }
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder()
            .AppendLine($"Lap {this.CurrentLap}/{this.totalLaps}");

        var position = 1;

        var leftDrivers = this.allDrivers.OrderBy(d => d.TotalTime).ToList();

        foreach (var driver in leftDrivers)
        {
            var name = driver.Name;
            var time = driver.TotalTime;

            result.AppendLine($"{position} {name} {time:f3}");

            position++;
        }

        foreach (var dnfDriver in dnf.Reverse())
        {
            result.AppendLine($"{position} {dnfDriver.Key} {dnfDriver.Value}");
            position++;
        }

        return result.ToString().TrimEnd();
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver = DriverFactory.CreateInstance(commandArgs);

            this.allDrivers.Add(driver);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLaps = lapsNumber;
        this.trackLength = trackLength;
    }

}