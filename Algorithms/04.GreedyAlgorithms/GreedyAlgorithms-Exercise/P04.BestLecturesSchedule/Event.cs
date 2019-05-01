namespace P04.BestLecturesSchedule
{
    public class Event
    {
        public Event(string lecture, int startTime, int endTime)
        {
            this.Lecture = lecture;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string Lecture { get; private set; }

        public int StartTime { get; private set; }

        public int EndTime { get; private set; }

        public override string ToString() => $"{this.StartTime}-{this.EndTime} -> {this.Lecture}";
    }
}
