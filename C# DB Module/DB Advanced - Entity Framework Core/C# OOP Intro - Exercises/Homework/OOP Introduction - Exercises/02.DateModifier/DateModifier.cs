using System;

public class DateModifier
{
    private int daysDifference;

    public int DaysDifference
    {
        get
        {
            return this.daysDifference;
        }
    }

    public void CalculateDateDifference(string firstDate, string secondDate)
    {
        string[] firstDateParams = firstDate.Split();
        string[] secondDateParams = secondDate.Split();

        DateTime dateOne = 
            new DateTime(int.Parse(firstDateParams[0]), int.Parse(firstDateParams[1]), int.Parse(firstDateParams[2]));

        DateTime dateTwo = 
            new DateTime(int.Parse(secondDateParams[0]), int.Parse(secondDateParams[1]), int.Parse(secondDateParams[2]));

        var daysDiff = Math.Abs((int)(dateOne - dateTwo).TotalDays);

        this.daysDifference = daysDiff;
    }
}