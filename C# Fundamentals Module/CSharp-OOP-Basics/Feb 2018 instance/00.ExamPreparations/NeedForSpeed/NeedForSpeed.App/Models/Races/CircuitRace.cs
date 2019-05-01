using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }

    public override string ToString()
    {
        var result = new StringBuilder()
            .AppendLine($"{this.Route} - {this.Length * this.Laps}");

        this.Participants
            .ToList()
            .ForEach(c => c.DecreaseDurabilityOnEachLap(this.Laps * this.Length * this.Length));

        var winners = this.Participants
            .OrderByDescending(c => c.GetOverallPerformance())
            .Take(4)
            .Select(c => new CarDto
            {
                Brand = c.Brand,
                Model = c.Model,
                PerformancePoints = c.GetOverallPerformance()
            })
            .ToList();

        var rank = 1;

        foreach (var carDto in winners)
        {
            var moneyWon = this.PrizePool * (5 - rank) / 10;

            result.AppendLine($"{rank++}. {carDto.Brand} {carDto.Model} {carDto.PerformancePoints}PP - ${moneyWon}");
        }

        return result.ToString().TrimEnd();
    }
}
