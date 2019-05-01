using System.Collections.Generic;
using System.Linq;

public class CarManager
{
    private const string InvalidStartCommand = "Cannot start the race with zero participants.";

    private IDictionary<int, Car> allCars;
    private IDictionary<int, Race> allRaces;
    private Garage garage;

    public CarManager()
    {
        this.allCars = new Dictionary<int, Car>();
        this.allRaces = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        Car car = null;

        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            default:
                break;
        }

        if (car != null)
        {
            this.allCars[id] = car;
        }
    }

    public string Check(int id)
    {
        var carTobeChecked = this
            .allCars
            .FirstOrDefault(c => c.Key == id)
            .Value;

        return carTobeChecked.ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race = null;

        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool);
                break;
            case "Drag":
                race = new DragRace(length, route, prizePool);
                break;
            case "Drift":
                race = new DriftRace(length, route, prizePool);
                break;
            default:
                break;
        }

        if (race != null)
        {
            this.allRaces[id] = race;
        }
    }

    public void Open(int id, string type, int length, string route, int prizePool, int speciaParam)
    {
        Race race = null;

        switch (type)
        {
            case "Circuit":
                race = new CircuitRace(length, route, prizePool, speciaParam);
                break;
            case "TimeLimit":
                race = new TimeLimitRace(length, route, prizePool, speciaParam);
                break;
            default:
                break;
        }

        if (race != null)
        {
            this.allRaces[id] = race;
        }
    }

    public void Participate(int carId, int raceId)
    {
        var car = this.allCars.FirstOrDefault(c => c.Key == carId).Value;
        var race = this.allRaces.FirstOrDefault(r => r.Key == raceId).Value;

        var isParked = this.garage.ParkedCars.Any(c => c == car);
        
        if (!isParked)
        {
            if (race.GetType().Name == "TimeLimitRace")
            {
                if (race.Participants.Count == 0)
                {
                    race.Participants.Add(car);
                }
            }
            else
            {
                race.Participants.Add(car);
            }
        }
    }

    public string Start(int raceId)
    {
        var race = this.allRaces.FirstOrDefault(r => r.Key == raceId).Value;

        if (race.Participants.Count > 0)
        {
            this.allRaces.Remove(raceId);
            return race.GetRanking();
        }

        return InvalidStartCommand;
    }

    public void Park(int carId)
    {
        var car = this.allCars.FirstOrDefault(c => c.Key == carId).Value;

        var isAvailableToPark = car != null && !IsParticipant(car);

        if (isAvailableToPark)
        {
            this.garage.ParkedCars.Add(car);
        }
    }
    
    public void Unpark(int carId)
    {
        var car = this.allCars.FirstOrDefault(c => c.Key == carId).Value;

        if (car != null && this.garage.ParkedCars.Any(c => c == car))
        {
            this.garage.ParkedCars.Remove(car);
        }
    }

    public void Tune(int tuneIndex, string addOn)
    {
        var carsTobeTuned = this.garage.ParkedCars.ToList();

        foreach (var car in carsTobeTuned)
        {
            car.Tune(tuneIndex, addOn);
        }
    }
    
    private bool IsParticipant(Car car)
    {
        var isParticipant = this
            .allRaces
            .Values
            .SelectMany(r => r.Participants)
            .Any(c => c == car);

        return isParticipant;
    }
}