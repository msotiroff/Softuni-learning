using System.Linq;
using System.Text;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override string ToString()
    {
        var result = new StringBuilder()
            .AppendLine(base.ToString());

        var winners = this.Participants
                .OrderByDescending(c => c.GetSuspensionPerformance())
                .Take(3)
                .Select(c => new CarDto
                {
                    Brand = c.Brand,
                    Model = c.Model,
                    PerformancePoints = c.GetSuspensionPerformance()
                })
                .ToList();

        var rank = 1;

        foreach (var carDto in winners)
        {
            var moneyWon = rank == 1
            ? this.PrizePool * 0.5
            : rank == 2
                ? this.PrizePool * 0.3
                : this.PrizePool * 0.2;

            result.AppendLine($"{rank++}. {carDto.Brand} {carDto.Model} {carDto.PerformancePoints}PP - ${moneyWon}");
        }

        return result.ToString().TrimEnd();
    }
}
