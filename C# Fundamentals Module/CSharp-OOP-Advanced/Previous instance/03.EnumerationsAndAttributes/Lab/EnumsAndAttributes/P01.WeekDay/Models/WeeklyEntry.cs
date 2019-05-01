using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    public WeekDay WeekDay  { get; private set; }

    public string Notes { get; private set; }
    
    public WeeklyEntry(string weekday, string notes)
    {
        this.WeekDay = this.ParseWeekDay(weekday);
        this.Notes = notes;
    }

    private WeekDay ParseWeekDay(string weekday)
    {
        WeekDay result;

        if (Enum.TryParse<WeekDay>(weekday, out result))
        {
            return result;
        }

        throw new ArgumentException("Invalid day of week");
    }

    public int CompareTo(WeeklyEntry other)
    {
        var result = this.WeekDay.CompareTo(other.WeekDay);

        if (result == 0)
        {
            result = this.Notes.CompareTo(other.Notes);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.WeekDay.ToString()} - {this.Notes}";
    }
}