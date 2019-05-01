using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private string weather;
    private int lapsCount;
    private int currentLap;
    private int trackLength;

    private IList<Driver> allDrivers;
    private IList<FailedDriverViewModel> failedDrivers;
    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;

    public RaceTower()
    {
        this.weather = "Sunny";
        this.allDrivers = new List<Driver>();
        this.failedDrivers = new List<FailedDriverViewModel>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
    }

    public int LapsLeft => this.lapsCount - this.currentLap;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.lapsCount = lapsNumber;
        this.trackLength = trackLength;
        this.currentLap = 0;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            Driver driver = this.driverFactory
                .CreateInstance(this.tyreFactory, commandArgs);

            this.allDrivers.Add(driver);
        }
        catch
        {
        }
    }

    public string GetWinnerInfo()
    {
        var winner = this.allDrivers.OrderBy(d => d.TotalTime).First();

        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reasonToBox = commandArgs[0];
        var driverName = commandArgs[1];

        var driver = this.allDrivers.FirstOrDefault(d => d.Name == driverName);
        driver.TotalTime += 20;

        switch (reasonToBox)
        {
            case "ChangeTyres":
                try
                {
                    Tyre tyre = this.tyreFactory.CreateInstance(commandArgs.Skip(2).ToArray());
                    driver.Car.ChangeTyres(tyre);
                }
                catch
                {
                }
                break;
            case "Refuel":
                var fuelAmount = double.Parse(commandArgs[2]);
                driver.Car.Refuel(fuelAmount);
                break;
            default:
                break;
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var numberOfLaps = int.Parse(commandArgs[0]);

        if (this.LapsLeft < numberOfLaps)
        {
            //throw new ArgumentException(string.Format(ErrorMessages.InvalidLapsCount, this.currentLap));

            return string.Format(ErrorMessages.InvalidLapsCount, this.currentLap);
        }

        var result = this.StartRacing(numberOfLaps);

        return result;
    }

    private string StartRacing(int numberOfLaps)
    {
        var result = string.Empty;

        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            this.currentLap++;

            for (int driverIndex = 0; driverIndex < allDrivers.Count; driverIndex++)
            {
                var currentDriver = allDrivers[driverIndex];

                try
                {
                    currentDriver.CompleteLap(this.trackLength);
                }
                catch (ArgumentException ex)
                {
                    var failedDriver = new FailedDriverViewModel(currentDriver.Name, ex.Message);
                    this.failedDrivers.Add(failedDriver);
                    this.allDrivers.RemoveAt(driverIndex);
                    driverIndex--;
                }
            }

            result += this.CheckForOvertakes();
        }

        return result.TrimEnd();
    }

    private string CheckForOvertakes()
    {
        var overtakes = new StringBuilder();

        var orderedDrivers = this.allDrivers.OrderByDescending(d => d.TotalTime).ToList();

        var overtakeInterval = 2.0;

        for (int currDriverIndex = 0; currDriverIndex < orderedDrivers.Count - 1; currDriverIndex++)
        {
            var currentDriver = orderedDrivers[currDriverIndex];
            var nextDriver = orderedDrivers[currDriverIndex + 1];

            var isCrashed = false;

            if (currentDriver.GetType().Name == nameof(AggressiveDriver)
                && currentDriver.Car.Tyre.GetType().Name == nameof(UltrasoftTyre))
            {
                overtakeInterval = 3.0;
                if (this.weather == "Foggy")
                {
                    isCrashed = true;
                }
            }
            else if (currentDriver.GetType().Name == nameof(EnduranceDriver)
                && currentDriver.Car.Tyre.GetType().Name == nameof(HardTyre))
            {
                overtakeInterval = 3.0;
                if (this.weather == "Rainy")
                {
                    isCrashed = true;
                }
            }

            if (currentDriver.TotalTime - nextDriver.TotalTime <= overtakeInterval)
            {
                if (isCrashed)
                {
                    var crashedDriver = new FailedDriverViewModel(currentDriver.Name, "Crashed");
                    this.failedDrivers.Add(crashedDriver);
                    this.allDrivers.Remove(currentDriver);
                }
                else
                {
                    currentDriver.TotalTime -= overtakeInterval;
                    nextDriver.TotalTime += overtakeInterval;
                    overtakes
                        .AppendLine($"{currentDriver.Name} has overtaken {nextDriver.Name} on lap {this.currentLap}.");
                    currDriverIndex++;
                }
            }
        }

        return overtakes.ToString();
    }

    public string GetLeaderboard()
    {
        var result = new StringBuilder()
            .AppendLine($"Lap {this.currentLap}/{this.lapsCount}");

        var rank = 1;

        foreach (var driver in this.allDrivers.OrderBy(d => d.TotalTime))
        {
            result
                .AppendLine($"{rank++} {driver.Name} {driver.TotalTime:f3}");
        }

        foreach (var driver in failedDrivers.Reverse())
        {
            result
                .AppendLine($"{rank++} {driver.Name} {driver.FailureReason}");
        }

        return result.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var newWeather = commandArgs.First();

        this.weather = newWeather;
    }

}
