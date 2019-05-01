using System;
using System.Linq;

public class DateModifier
{
    public string FirstDate { get; set; }

    public string SecondDate { get; set; }

    public DateModifier(string dateOne, string dateTwo)
    {
        this.FirstDate = dateOne;
        this.SecondDate = dateTwo;
    }

    public string GetDifference()
    {
        var firstDateArgs = this.FirstDate.Split().Select(int.Parse).ToArray();
        var secondDateArgs = this.SecondDate.Split().Select(int.Parse).ToArray();

        var diff = new DateTime(firstDateArgs[0], firstDateArgs[1], firstDateArgs[2]) - new DateTime(secondDateArgs[0], secondDateArgs[1], secondDateArgs[2]);

        return Math.Abs(diff.Days).ToString();
    }
}
