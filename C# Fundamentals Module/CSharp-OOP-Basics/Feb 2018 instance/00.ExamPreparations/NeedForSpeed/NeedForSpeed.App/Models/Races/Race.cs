using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    protected Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new List<Car>();
    }

    public int Length { get; private set; }

    public string Route { get; private set; }

    public int PrizePool { get; private set; }

    public IList<Car> Participants { get; private set; }

    public void AddParticipant(Car car)
    {
        this.Participants.Add(car);
    }

    public override string ToString()
    {
        return $"{this.Route} - {this.Length}";
    }
}
