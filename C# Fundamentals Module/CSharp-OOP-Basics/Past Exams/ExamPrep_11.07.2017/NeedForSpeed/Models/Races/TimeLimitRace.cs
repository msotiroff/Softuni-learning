using System;
using System.Linq;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }

    public override string GetRanking()
    {
        var performancePoints = this
            .Participants
            .First()
            .GetTimePerformance() * this.Length;

        var timeRank = 0.3d;
        var earnedTime = "Bronze";

        if (performancePoints <= this.GoldTime)
        {
            timeRank = 1;
            earnedTime = "Gold";
        }
        else if (performancePoints <= this.GoldTime + 15)
        {
            timeRank = 0.5;
            earnedTime = "Silver";
        }

        var result = $"{this.Route} - {this.Length}{Environment.NewLine}";
        result += $"{this.Participants.First().Brand} {this.Participants.First().Model} - {performancePoints} s.{Environment.NewLine}";
        result += $"{earnedTime} Time, ${(int)(this.PrizePool * timeRank)}.";

        return result;
    }
}