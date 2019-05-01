using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    public TimeLimitRace(int length, string route, int prizePool, int goldTime)
        : base(length, route, prizePool)
    {
        this.GoldTime = goldTime;
    }

    public int GoldTime { get; private set; }

    public override string ToString()
    {
        var participant = this.Participants.First();
        var participantTime = participant.GetTimePerformance(this.Length);

        var participantEarnedTime = "Bronze";
        var wonPrize = this.PrizePool * 3 / 10;

        if (participantTime <= this.GoldTime + 15)
        {
            participantEarnedTime = "Silver";
            wonPrize = this.PrizePool / 2;
        }

        if (participantTime < this.GoldTime)
        {
            participantEarnedTime = "Gold";
            wonPrize = this.PrizePool;
        }

        var result = new StringBuilder()
            .AppendLine($"{this.Route} - {this.Length}")
            .AppendLine($"{participant.Brand} {participant.Model} - {participantTime} s.")
            .Append($"{participantEarnedTime} Time, ${wonPrize}.");

        return result.ToString();
    }
}
