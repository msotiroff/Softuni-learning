using System.Collections.Generic;

public class WeeklyCalendar
{
    public IList<WeeklyEntry> WeeklySchedule { get; private set; } = new List<WeeklyEntry>();

    public void AddEntry(string weekday, string notes)
    {
        var weeklyEntry = new WeeklyEntry(weekday, notes);

        this.WeeklySchedule.Add(weeklyEntry);
    }
}
