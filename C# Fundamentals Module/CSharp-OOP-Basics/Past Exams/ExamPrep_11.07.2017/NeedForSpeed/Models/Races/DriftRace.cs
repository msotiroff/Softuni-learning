using System;
using System.Linq;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override string GetRanking()
    {
        var performancePointsRanking = this
            .Participants
            .OrderByDescending(c => c.GetSuspensionPerformance())
            .Take(3)
            .ToList();

        var result = $"{this.Route} - {this.Length}{Environment.NewLine}";

        var rank = 1;

        foreach (var car in performancePointsRanking)
        {
            var moneyWon = rank == 1 
                ? this.PrizePool * 0.5 
                : rank == 2 
                    ? this.PrizePool * 0.3 
                    : this.PrizePool * 0.2;

            result += $"{rank++}. {car.Brand} {car.Model} {car.GetSuspensionPerformance()}PP - ${moneyWon}{Environment.NewLine}";
        }

        return result.TrimEnd();
    }
}
