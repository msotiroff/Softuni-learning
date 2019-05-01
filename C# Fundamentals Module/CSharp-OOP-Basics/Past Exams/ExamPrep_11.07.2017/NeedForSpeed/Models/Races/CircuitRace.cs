using System;
using System.Linq;

public class CircuitRace : Race
{
    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.Laps = laps;
    }

    public int Laps { get; private set; }

    public override string GetRanking()
    {
        var performancePointsRanking = this
            .Participants
            .OrderByDescending(c => c.GetOverallPerformance())
            .Take(4)
            .ToList();

        this.Participants
            .ToList()
            .ForEach(c => c.Durability -= (this.Laps * this.Length * this.Length));

        var result = $"{this.Route} - {this.Length * this.Laps}{Environment.NewLine}";

        var rank = 1;

        foreach (var car in performancePointsRanking)
        {
            var moneyWon = rank == 1
                ? (int)(this.PrizePool * 0.4)
                : rank == 2
                    ? (int)(this.PrizePool * 0.3)
                    : rank == 3
                        ? (int)(this.PrizePool * 0.2)
                        : (int)(this.PrizePool * 0.1);

            result += $"{rank++}. {car.Brand} {car.Model} {car.GetOverallPerformance()}PP - ${moneyWon}{Environment.NewLine}";
        }

        return result.TrimEnd();
    }
}