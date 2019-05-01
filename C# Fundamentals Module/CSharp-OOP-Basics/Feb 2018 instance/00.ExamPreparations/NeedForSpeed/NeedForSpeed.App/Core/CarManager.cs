using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CarManager
{
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

        this.allCars.Add(id, car);
    }

    public string Check(int id)
    {
        var car = this.allCars[id];

        return car.ToString();
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

        this.allRaces.Add(id, race);
    }

    public void Open(int id, string type, int length, string route, int prizePool, int additionalParameter)
    {
        Race race = null;

        switch (type)
        {
            case "TimeLimit":
                race = new TimeLimitRace(length, route, prizePool, additionalParameter);
                break;
            case "Circuit":
                race = new CircuitRace(length, route, prizePool, additionalParameter);
                break;
            default:
                break;
        }

        this.allRaces.Add(id, race);
    }

    public void Participate(int carId, int raceId)
    {
        var car = this.allCars[carId];
        var race = this.allRaces[raceId];

        var isParked = this.garage
            .ParkedCars
            .Any(c => c == car);

        if (isParked)
        {
            return;
        }

        if (race.GetType().Name == nameof(TimeLimitRace))
        {
            if (race.Participants.Count < 1)
            {
                race.AddParticipant(car);
                return;
            }
        }
        
        race.AddParticipant(car);
    }

    public string Start(int id)
    {
        var race = this.allRaces[id];

        if (race.Participants.Count == 0) // a race CANNOT start without ANY participants.
        {
            return "Cannot start the race with zero participants.";
        }

        var result = race.ToString();
        
        this.allRaces.Remove(id);
        
        return result;
    }

    public void Park(int id)
    {
        var car = this.allCars[id];

        var isParticipant = this.allRaces
            .SelectMany(r => r.Value.Participants)
            .Any(c => c == car);

        if (!isParticipant)
        {
            this.garage.Park(car);
        }
    }

    public void Unpark(int id)
    {
        var car = this.allCars[id];

        this.garage.Unpark(car);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        var carsToBeTuned = this.garage
            .ParkedCars
            .ToList();

        carsToBeTuned
            .ForEach(c => c.Tune(tuneIndex, addOn));
    }
}
